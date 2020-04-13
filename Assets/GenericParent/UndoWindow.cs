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

	public void OnGUI()
	{
		GUILayout.Space(5);

		array = (ArrayUndo<T>)EditorGUILayout.ObjectField(array, typeof(ArrayUndo<T>), true);

		GUILayout.Label("Current value");
		GUILayout.Label("value: " + value.ToString());

		ChangeValue();

		if (GUILayout.Button("Apply", GUILayout.Height(20)))
		{
			ApplyVertexFactors(value);
		}
	}

	protected virtual void ChangeValue()
	{
	}

	public void ApplyVertexFactors(T factor)
	{
		if (array == null)
			return;


		Undo.RecordObject(array, "Modify Vertices");

		array.Add(factor);
		array.Log();
	}

	private void UndoRedoCallback()
	{
		if (array == null)
		{
			return;
		}

		T[] copy = array.array;
		array.array = copy;
		array.index = array.index;
	}
}
