using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour {

	private QuestsSystem questsSystem;
	public LerpController lerpToQuestCamera;
	public GameObject QuestObjects;
	[TextArea]
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
	public void Init(QuestsSystem qs)
	{
		questsSystem = qs;
	}
}
