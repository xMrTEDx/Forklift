using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour {

	public LerpTo_Camera_Controller lerpToPlayer;
	public LerpTo_Camera_Controller lerpToQuestCamera;
	public string description;
	public Goal[] cele;
	public class Goal
	{
		public StatusZadania status;
		public string opis;

		public enum StatusZadania
		{
			oczekujace,
			wykonane,
			niewykonane,
		}
	}

	public void ShowQuest()
	{
		gameObject.SetActive(true);
		lerpToQuestCamera.CameraLerpTo();
	}
}
