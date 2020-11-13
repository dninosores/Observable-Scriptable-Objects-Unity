using System;
using System.Collections.Generic;

/// <summary>
/// Automatically manages subscriptions, unsubscriptions, and event callbacks for an Observable.
/// </summary>
/// <typeparam name="T">Type of object that is being observed.</typeparam>
public class AutoObservable<T> : Observable<T> {

	private class ActionContainer<R> : IDisposable
	{
		private HashSet<Action<R>> actions;
		private Action<R> action;

		public ActionContainer(HashSet<Action<R>> actions, Action<R> action)
		{
			this.actions = actions;
			this.action = action;
		}

		public void Dispose()
		{
			actions.Remove(action);
		}
	}

	private HashSet<Action<T>> actions = new HashSet<Action<T>>();

	public AutoObservable() {
		this.actions = new HashSet<Action<T>>();
	}

	public IDisposable Subscribe(Action<T> onChange)
	{
		actions.Add(onChange);
		return new ActionContainer<T>(actions, onChange);
	}

	public void Unsubscribe(Action<T> onChange)
	{
		actions.Remove(onChange);
	}

	public void UnsubscribeAll()
	{
		actions.Clear();
	}

	/// <summary>
	/// Alerts all listeners that the value of the scriptable object has changed.
	/// </summary>
	/// <param name="newValue">The new value of the scriptable object.</param>
	public void AlertValueChange(T newValue)
	{
		foreach (Action<T> a in actions)
		{
			a(newValue);
		}
	}
}
