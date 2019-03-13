using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIcontroller : MonoBehaviour {

	public MainMenuController mainMenuController;
	public BlackoutController blackoutController;

	public void Init()
	{
		mainMenuController.Init();

		blackoutController.Init();
	}
}
