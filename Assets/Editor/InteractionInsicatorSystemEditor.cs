using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(InteractionIndicatorSystem)),CanEditMultipleObjects]
public class InteractionInsicatorSystemEditor : Editor {

	public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        InteractionIndicatorSystem myScript = (InteractionIndicatorSystem)target;
        if(GUILayout.Button("Find All II"))
        {
            myScript.FindAllIIfromScene();
        }
    }
	
}
