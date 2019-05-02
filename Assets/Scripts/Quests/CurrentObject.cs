using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentObject : MonoBehaviour {

	public void SetCurrentObject()
	{
		GameManager.Instance.QuestsSystem.currentQuest.quest.currentObject = gameObject;
	}
	public void ClearObject()
	{
		GameManager.Instance.QuestsSystem.currentQuest.quest.currentObject = null;
	}
}
