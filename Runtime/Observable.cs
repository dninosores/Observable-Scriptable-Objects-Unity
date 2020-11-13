
using System;
/// <summary>
/// An object that can notify other objects when its state changes.
/// </summary>
public interface Observable<T>
{
	/// <summary>
	/// Tells scriptable object to call the given method with its new value every time the value changes. 
	/// The same action cannot be added twice.
	/// </summary>
	/// <param name="onChange">Method to call when value changes</param>
	/// <returns>IDisposable that will unsubscribe the action from the scriptable object when its Dispose() method is called.</returns>
	IDisposable Subscribe(Action<T> onChange);


	/// <summary>
	/// Will no longer call given action when scriptable object updates.
	/// </summary>
	/// <param name="onChange">Action to stop calling.</param>
	void Unsubscribe(Action<T> onChange);


	/// <summary>
	/// Unsubscribes all listeners from observable.
	/// </summary>
	void UnsubscribeAll();
}
