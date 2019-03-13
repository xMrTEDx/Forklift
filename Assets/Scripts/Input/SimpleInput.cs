using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="ButtonsManager/SimpleInput"), System.Serializable]
public class SimpleInput : ScriptableObject {

	public List<KeyCode> przyciski;
    public List<string> osie;
	public InputManager.InputAction inputAction;
}
