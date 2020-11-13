using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableList<T> : ScriptableIList<T>
{
	protected override IList<T> internalList => throw new System.NotImplementedException();
}
