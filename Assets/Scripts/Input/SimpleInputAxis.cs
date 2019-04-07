using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ButtonsManager/SimpleInputAxis")]
public class SimpleInputAxis : ScriptableObject {

	public List<Przyciski> przyciski;
    public List<string> osie;
	public InputManager.InputAction inputAction;
	[System.Serializable]
	public class Przyciski{
		public KeyCode wartoscDodatnia;
		public KeyCode wartoscUjemna;
	}
}
