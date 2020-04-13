using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GenericWindow<T> : EditorWindow where T : MonoBehaviour
{
}


public class UndoWindow<T> : GenericWindow<ArrayUndo<T>>
{
	public ArrayUndo<T> array = null;
	public T value;

	private void OnEnable()
	{
		Undo.undoRedoPerformed += this.UndoRedoCallback;
		array = GameObject.FindObjectOfType<ArrayUndo<T>>();
	}

	private void OnGUI()
	{
		GUILayout.Space(5);

		array = (ArrayUndo<T>)EditorGUILayout.ObjectField(array, typeof(ArrayUndo<T>), true);

		GUILayout.Label("Current value");
		ShowValue();

		ChangeValue();

		if (GUILayout.Button("Apply", GUILayout.Height(20)))
		{
			if (array == null)
				return;

			Undo.RecordObject(array, "Modify Vertices");

			ApplyVertexFactors();
		}
	}

	protected virtual void ShowValue()
	{
		GUILayout.Label("value: " + value);
	}

	protected virtual void ChangeValue()
	{
	}

	protected virtual void ApplyVertexFactors()
	{
		array.Add(value);
		array.Log();
	}

	protected virtual void UndoRedoCallback()
	{
		if (array == null)
		{
			return;
		}

		T[] copy = array.array;
		array.array = copy;
		int index = array.index;
		array.index = index;
	}
}
