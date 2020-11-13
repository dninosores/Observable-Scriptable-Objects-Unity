using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScriptableIList<T> : AutoObservableScriptableObject<IList<T>>, IList<T>
{
	protected abstract IList<T> internalList { get; }


	public T this[int index]
	{
		get => internalList[index]; 
		set
		{
			internalList[index] = value;
			AlertValueChange(internalList);
		}
	}

	public int Count => internalList.Count;

	public bool IsReadOnly => internalList.IsReadOnly;

	public void Add(T item)
	{
		internalList.Add(item);
		AlertValueChange(internalList);
	}

	public void Clear()
	{
		internalList.Clear();
		AlertValueChange(internalList);
	}

	public bool Contains(T item)
	{
		return internalList.Contains(item);
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		internalList.CopyTo(array, arrayIndex);
	}

	public IEnumerator<T> GetEnumerator()
	{
		return internalList.GetEnumerator();
	}

	public int IndexOf(T item)
	{
		return internalList.IndexOf(item);
	}

	public void Insert(int index, T item)
	{
		internalList.Insert(index, item);
		AlertValueChange(internalList);
	}

	public bool Remove(T item)
	{
		bool status = internalList.Remove(item);
		if (status)
		{
			AlertValueChange(internalList);
		}
		return status;
	}

	public void RemoveAt(int index)
	{
		internalList.RemoveAt(index);
		AlertValueChange(internalList);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return internalList.GetEnumerator();
	}
}
