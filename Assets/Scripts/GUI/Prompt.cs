using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prompt : Singleton<Prompt> {

    public Animator animator;
    public Text text;

    public void ShowPrompt(string textToShow)
    {
        text.text = textToShow;
        animator.SetTrigger("ShowPrompt");
    }
	
}
