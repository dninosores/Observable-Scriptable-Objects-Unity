using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An ObservableScriptableObject that contains a value of type T that can be set and accessed externally.
/// </summary>
/// <typeparam name="T">Type of value that </typeparam>
public class ScriptableContainer<T> : AutoObservableScriptableObject<T>
{
	/// <summary>
	/// Value contained by ScriptableContainer. Modifying this value will alert all listeners.
	/// </summary>
	public T value
	{
		get
		{
			return Value;
		}
		set
		{
			Value = value;
			AlertValueChange(Value);
		}
	}

	// Internally stored value used to allow for serialization of value in editor (has same name to create illusion that this
	// is the same field as 'value'.
	[SerializeField, Tooltip("Value stored in scriptable object")]
	private T Value;

	// Sends alerts when the editor value changes so that changing a value in play mode has same effect as
	// having value changed by script.
	private void OnValidate()
	{
		AlertValueChange(Value);
	}
}
