using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : Singleton<MainPlayer> {
	public UnityStandardAssets.Characters.FirstPerson.FirstPersonController firstPersonController;
	public GameObject character;
	public GameObject camera;

	public void DisablePlayer()
	{
		//character.SetActive(false);
	}
	public void EnablePlayer()
	{
		//character.SetActive(true);
		//Camera.SetupCurrent(character.GetComponent<Camera>());
		camera.transform.rotation = new Quaternion(0,0,0,0);
		PlayerStatesSystem.Instance.SetPlayerState("walking");
		
	}
}
