using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;
using UnityEditorInternal;

//[CustomEditor(typeof(InputManager))]
public class InputManagerEditor : Editor {

	InputManager inputManager;
	ReorderableList buttonsList;

	float lineHeight;
	float lineHeightSpace;

	void OnEnable()
	{
		if(target == null) return;

		lineHeight = EditorGUIUtility.singleLineHeight;
		lineHeightSpace = lineHeight +10;

		inputManager = (InputManager)target;
		buttonsList = new ReorderableList(serializedObject, serializedObject.FindProperty("przyciski"),true,true,true,true);
	
		buttonsList.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
		{
			SerializedProperty element = buttonsList.serializedProperty.GetArrayElementAtIndex(index);
			SerializedObject elementObj = new SerializedObject (element.objectReferenceValue);

			EditorGUI.LabelField(new Rect(rect.x,rect.y,rect.width, lineHeight),elementObj.FindProperty("Name").stringValue);
		
			SerializedProperty propertyIterator = elementObj.GetIterator();

			int i =0;
			while(propertyIterator.NextVisible(true))
			{
				EditorGUI.PropertyField(new Rect(rect.x,rect.y + (lineHeightSpace*i),rect.width,lineHeight),propertyIterator);
				i++;
			}
		};

		buttonsList.elementHeightCallback = (int index) =>
		{
			float height = 0;

			SerializedProperty element = buttonsList.serializedProperty.GetArrayElementAtIndex(index);
			SerializedObject elementObj = new SerializedObject (element.objectReferenceValue);

			SerializedProperty propertyIterator = elementObj.GetIterator();

			int i =0;
			while(propertyIterator.NextVisible(true))
			{
				i++;
			}

			height = lineHeightSpace * i;

			return height;
		};
	}
	
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		buttonsList.DoLayoutList();
	}
}
