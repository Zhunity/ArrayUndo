using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TwoDArrayUndo : ArrayUndo<int[]>
{
	public void Add(int value)
	{
		int height = array.Length;
		int width = 10;
		index %= (height * width);
		int i = index % height;
		int j = index / height;
		if(array[j] == null)
		{
			array[j] = new int[width];
		}
		array[j][i] = value;
		index++;
	}

	public void Set(int index, int value)
	{
		int height = array.Length;
		int width = 10;
		int i = index % height;
		int j = index / height;
		if (array[j] == null)
		{
			array[j] = new int[width];
		}
		array[j][i] = value;
	}

	public override void Log()
	{
		Debug.Log(array[0][0]);
	}
}


public class TwoDArrayUndoWindow : UndoWindow<int[]>
{
	int num = 1;

	[MenuItem("Undo/2D Array")]
	static void OpenWindow()
	{
		var window = EditorWindow.GetWindow<TwoDArrayUndoWindow>();
		window.Show();
	}

	protected override void ShowValue()
	{
		GUILayout.Label("value: " + num);
	}

	protected override void ChangeValue()
	{
		if (GUILayout.Button("Add", GUILayout.Height(17)))
		{
			num *= 2;
		}

		if (GUILayout.Button("Sub", GUILayout.Height(17)))
		{
			num /= 2;
		}
	}

	protected override void ApplyVertexFactors()
	{
		var twoDArrayUndo = array as TwoDArrayUndo;
		twoDArrayUndo.Set(0, num);
		twoDArrayUndo.Add(num);
		twoDArrayUndo.Log();
	}

	protected override void UndoRedoCallback()
	{
		/*
		 * 用原本的方法，是不能还原的
		base.UndoRedoCallback();
		*/

		/*
		 * 数组复制，也是不行的
		for(int i = 0; i < array.array.Length; i ++ )
		{
			int[] copy = array.array[i];
			array.array[i] = copy;
		}
		*/

		/*
		 * 一个一个赋值，也是不行的
		for (int i = 0; i < array.array.Length; i++)
		{
			if(array.array[i] == null)
			{
				continue;
			}
			int length = array.array[i].Length;
			int[] copy = new int[length];
			for (int j = 0; j < length; j ++)
			{
				copy[j] = array.array[i][j];
			}
			array.array[i] = copy;
		}
		*/

		int index = array.index;
		array.index = index;
		array.Log();
	}
}