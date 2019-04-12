using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	public static GameObject currentPlayer;
	public static CharacterController characterController;
	public static LerpController lerpController;
	public void SetPlayer(GameObject player)
	{
		currentPlayer = player;
		characterController = player.GetComponent<CharacterController>();
		lerpController = player.GetComponentInChildren<LerpController>();
	}
	public void PlayerLerpTo()
	{
		lerpController.CameraLerpTo();
	}
}
