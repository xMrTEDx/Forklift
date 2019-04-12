using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIcontroller : MonoBehaviour {

	public MainMenuController mainMenuController;
	public PauseMenuManager pauseMenuManager;
	public BlackoutController blackoutController;
	public QuestsScreenController questsScreen;
	public PressAnyKeyController pressAnyKeyController;
	public InfoBoxManager InfoBoxManager;

	public void Init()
	{
		mainMenuController.Init();

		blackoutController.Init();

		pressAnyKeyController.Init();

		pauseMenuManager.Init();
		InfoBoxManager.Init();
	}
}
