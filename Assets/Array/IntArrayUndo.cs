using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class IntArrayUndo : ArrayUndo<int>
{
}

public class IntArrayUndoWindow : UndoWindow<int>
{

	[MenuItem("Undo/Int")]
	static void OpenWindow()
	{
		var window = EditorWindow.GetWindow<IntArrayUndoWindow>();
		window.Show();
	}

	protected override void ChangeValue()
	{
		if (GUILayout.Button("Add", GUILayout.Height(17)))
		{
			value += 2;
		}

		if (GUILayout.Button("Sub", GUILayout.Height(17)))
		{
			value -= 2;
		}
	}
}



