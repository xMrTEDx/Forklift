using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InputManager : MonoBehaviour {
	[Header("Przyciski")]
    public List<InputButton> przyciski;


    public enum Akcje{
        interakcja,
        menu,
        skok,
        bieg
    }

    [System.Serializable]
    public class InputButton
    {
        public Akcje akcja;
        public List<KeyCode> przyciski;
    }
    


    // [Header("Osie")]
    // public InputAxis gaz;

    // public enum Osie{
    //     Gaz,
    //     Hamulec
    // }

    //[System.Serializable]
    // public class InputAxis
    // {
    //     public Osie os;
    //     public List<string> osie;
    // }
}

