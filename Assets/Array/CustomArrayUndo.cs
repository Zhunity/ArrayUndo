using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CustomArray<T> // 带了泛型就显示不出来了。。。
{
	[SerializeField]
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
	[SerializeField]
	public CustomArray<int> a = new CustomArray<int>();	// 显示不出来。。。
}
