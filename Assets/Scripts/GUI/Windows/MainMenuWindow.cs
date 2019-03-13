using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuWindow : Window {

	MainMenuController mainMenuController;
	public void Init(MainMenuController mmController)
	{
		mainMenuController = mmController;
	}
	public override void EnableWindow()
	{
		base.EnableWindow();
		mainMenuController.CurrentWindow = this;
	}
}
