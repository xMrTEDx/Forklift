using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CurrentObjectEnterTrigger : MonoBehaviour {

	public UnityEvent e_OnTriggerEnterAction;

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject == GameManager.Instance.QuestsSystem.currentQuest.quest.currentObject)
		{
			GameManager.Instance.QuestsSystem.currentQuest.quest.currentObject = null;
			e_OnTriggerEnterAction.Invoke();
			//gameObject.SetActive(false);
		}
	}
}
