using UnityEngine;
using UnityEditor;

namespace Klak.Wiring
{
	[CanEditMultipleObjects]
	[CustomEditor(typeof(TransformOut2))]
	public class TransformOut2Editor : Editor
	{
		SerializedProperty _targetTransform;
		SerializedProperty _addToOriginal;

		void OnEnable()
		{
			_targetTransform = serializedObject.FindProperty("_targetTransform");
			_addToOriginal = serializedObject.FindProperty("_addToOriginal");
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			EditorGUILayout.PropertyField(_targetTransform);
			EditorGUILayout.PropertyField(_addToOriginal);

			serializedObject.ApplyModifiedProperties();
		}
	}
}
