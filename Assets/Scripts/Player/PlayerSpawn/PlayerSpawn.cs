using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour {

	public GameObject cameraRotate;

	public void SetPlayerPosition()
	{
		MainPlayer.Instance.gameObject.transform.position = transform.position;
		MainPlayer.Instance.gameObject.transform.rotation = transform.rotation;

		MainPlayer.Instance.character.transform.rotation = cameraRotate.transform.rotation;


		//Camera.main.transform.localRotation = cameraRotate.transform.localRotation;
		//Camera.main.transform.rotation = cameraRotate.transform.rotation;

	}
	void OnDrawGizmos()
	{
		Gizmos.DrawWireCube(transform.position,new Vector3(1.5f,7f,1.5f));
	}
}
