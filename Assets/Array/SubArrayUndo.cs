using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[Serializable]
public class SubArray
{
	public int[] a = new int[10];
}

public class SubArrayUndo : ArrayUndo<SubArray>
{
	public void Add(int value)
	{
		int height = array.Length;
		int width = array[0].a.Length;
		index %= (height * width);
		int i = index % height;
		int j = index / height;
		array[j].a[i] = value;
		index++;
	}

}

public class SubArrayUndoWindow : UndoWindow<SubArray>
{
	int num = 1;

	[MenuItem("Undo/Sub Array")]
	static void OpenWindow()
	{
		var window = EditorWindow.GetWindow<SubArrayUndoWindow>();
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
		var subArrayUndo = array as SubArrayUndo;
		subArrayUndo.Add(num);
	}
}