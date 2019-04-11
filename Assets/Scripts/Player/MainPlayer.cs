using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour {
	public UnityStandardAssets.Characters.FirstPerson.FirstPersonController firstPersonController;
	public GameObject character;
	public static MainPlayer currentPlayer;
	//public GameObject camera;

	public void DisablePlayer()
	{
		gameObject.SetActive(false);
	}
	public void EnablePlayer()
	{
		gameObject.SetActive(true);
		currentPlayer = this;
		Camera.main.transform.localRotation = Quaternion.identity;
		GameManager.Instance.PlayerStatesSystem.SetPlayerState("walking");
		
	}
}
