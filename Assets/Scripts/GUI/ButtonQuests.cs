using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonQuests : Button {

	public int questNumber;

	public override void OnSelect(UnityEngine.EventSystems.BaseEventData eventData)
	{
		base.OnSelect(eventData);
		GameManager.Instance.GUIcontroller.questsScreen.SelectQuest(questNumber);
		GameManager.Instance.QuestsSystem.ShowQuest(questNumber);
	}
}
