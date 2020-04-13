using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class IntArrayUndo : ArrayUndo<int>
{
}

public class IntArrayUndoWindow : EditorWindow
{
	public IntArrayUndo array = null;
	public int value = 1;

	[MenuItem("Undo/Int")]
	static void OpenWindow()
	{
		var window = EditorWindow.GetWindow<IntArrayUndoWindow>();
		window.Show();
	}

	private void OnEnable()
	{
		Undo.undoRedoPerformed += this.UndoRedoCallback;
	}

	public void OnGUI()
	{
		GUILayout.Space(5);

		array = (IntArrayUndo)EditorGUILayout.ObjectField(array, typeof(IntArrayUndo), true);

		GUILayout.Label("Current value");

		GUILayout.Label("value: " + value.ToString());

		if (GUILayout.Button("Expand", GUILayout.Height(17)))
		{
			value *= 2;
		}

		if (GUILayout.Button("Shrink", GUILayout.Height(17)))
		{
			value /= 2;
		}

		if (GUILayout.Button("Apply", GUILayout.Height(20)))
		{
			ApplyVertexFactors(value);
		}
	}

	public void ApplyVertexFactors(int factor)
	{
		if (array == null)
			return;


		Undo.RecordObject(array, "Modify Vertices");

		array.Add(factor);
		array.Log();
	}

	private void UndoRedoCallback()
	{
		if(array == null)
		{
			return;
		}

		int[] copy = array.array;
		array.array = copy;
		array.index = array.index;
	}
}



