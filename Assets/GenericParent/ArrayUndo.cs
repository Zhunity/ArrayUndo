using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ArrayUndo<T> : MonoBehaviour
{
	public int index = 0;

	[SerializeField]
	public T[] array = new T[10];

	public void Add(T value)
	{
		index %= array.Length;
		array[index] = value;
		index++;
	}

	public void Set(int i, T value)
	{
		i %= array.Length;
		array[i] = value;
	}

	public void Log()
	{
		for(int i = 0; i < array.Length; i ++)
		{
			Debug.Log(i + " : " + array[i]);
		}
	}
}
