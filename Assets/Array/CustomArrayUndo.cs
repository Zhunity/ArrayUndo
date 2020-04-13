using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CustomArray<T>
{
	public T[] Array;
	public T this[int index]
	{
		get
		{
			return Array[index];
		}
	}
	public CustomArray()
	{
		this.Array = new T[4];
	}

	public CustomArray(int length)
	{
		this.Array = new T[length];
	}
}

public class CustomArrayUndo : MonoBehaviour
{
}
