using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SimpleWingEditor : Editor
{
	private bool showDebug = false;

	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		SimpleWings wing = (SimpleWings)target;

		EditorGUILayout.Space();
		showDebug = EditorGUILayout.ToggleLeft("Show debug values", showDebug);

		if (showDebug)
		{
			EditorGUILayout.Space();
			EditorGUILayout.LabelField("Wing Area: ", wing.WingArea.ToString("0.00"));
			EditorGUILayout.LabelField("Angle of Attack: ", wing.AngleOfAttack.ToString("0.00"));

			EditorGUILayout.Space();
			EditorGUILayout.LabelField("Lift Coefficient: ", wing.LiftCoefficient.ToString("0.00"));
			EditorGUILayout.LabelField("Lift Force: ", wing.LiftForce.ToString("0.00"));

			EditorGUILayout.Space();
			EditorGUILayout.LabelField("Drag Coefficient: ", wing.DragCoefficient.ToString("0.00"));
			EditorGUILayout.LabelField("Drag Force: ", wing.DragForce.ToString("0.00"));

			if (Application.isPlaying)
			{
				Repaint();
			}
		}
	}
}
