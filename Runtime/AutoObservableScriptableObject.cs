using System;
using System.Collections.Generic;

/// <summary>
/// Automatically manages the listeners subscribed to ObservableScriptableObject.
/// </summary>
/// <typeparam name="T">The type of value the scriptable object contains.</typeparam>
public abstract class AutoObservableScriptableObject<T> : ObservableScriptableObject<T>
{
	private AutoObservable<T> container = new AutoObservable<T>();

	public override IDisposable Subscribe(Action<T> onChange)
	{
		return container.Subscribe(onChange);
	}

	public override void Unsubscribe(Action<T> onChange)
	{
		container.Unsubscribe(onChange);
	}

	public override void UnsubscribeAll()
	{
		container.UnsubscribeAll();
	}

	/// <summary>
	/// Alerts all listeners that the value of the scriptable object has changed.
	/// </summary>
	/// <param name="newValue">The new value of the scriptable object.</param>
	protected void AlertValueChange(T newValue)
	{
		container.AlertValueChange(newValue);
	}
}
