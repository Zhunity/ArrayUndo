using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Vector2ArrayUndo : ArrayUndo<Vector2>
{
}

public class Vector2ArrayUndoWindow : UndoWindow<Vector2>
{

	[MenuItem("Undo/Vector2")]
	static void OpenWindow()
	{
		var window = EditorWindow.GetWindow<Vector2ArrayUndoWindow>();
		window.Show();
	}

	protected override void ChangeValue()
	{
		if (GUILayout.Button("Add", GUILayout.Height(17)))
		{
			value += Vector2.one * 2f;
		}

		if (GUILayout.Button("Sub", GUILayout.Height(17)))
		{
			value -= Vector2.one * 2f;
		}
	}
}