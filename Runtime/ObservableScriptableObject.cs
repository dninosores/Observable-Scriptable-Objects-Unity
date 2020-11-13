using System;
using UnityEngine;

public abstract class ObservableScriptableObject<T> : ScriptableObject, Observable<T>
{
	public abstract IDisposable Subscribe(Action<T> onChange);
	public abstract void Unsubscribe(Action<T> onChange);
	public abstract void UnsubscribeAll();
}
