using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LerpTo_Player_Controller : MonoBehaviour {

	[Range(0.1f,3.6f)]
	public float lerpSpeed = 2.2f;
	public UnityEvent e_OnLerpFinished = new UnityEngine.Events.UnityEvent();
	
	/*public void PlayerLerpTo()
	{
		GameManager.Instance.PlayerStatesSystem.SetPlayerState("None");

		StartCoroutine(SetPlayerTransform());
	}
	IEnumerator SetPlayerTransform()
	{
		Vector3 playerPosition;
		Quaternion playerRotation = MainPlayer.Instance.transform.rotation;
		Quaternion cameraRotation = Camera.main.transform.rotation;

		float hlp=0;
		while(hlp<1)
		{
			hlp+=lerpSpeed*Time.deltaTime;

			MainPlayer.Instance.transform.rotation = Quaternion.Lerp(playerRotation,gameObject.transform.rotation,hlp);
			Camera.main.transform.rotation = Quaternion.Lerp(cameraRotation,gameObject.transform.rotation,hlp);
			playerPosition = Vector3.Lerp(MainPlayer.Instance.transform.position,gameObject.transform.position,hlp);
			MainPlayer.Instance.transform.position= new Vector3(playerPosition.x,MainPlayer.Instance.transform.position.y,playerPosition.z);
			
			yield return null;
		}
		
		e_OnLerpFinished.Invoke();

		yield return null;
		
	}*/
	
	void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, (transform.position + transform.forward * 10));
		Gizmos.DrawSphere(transform.position,0.5f);
    }
}
