using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonController : Button {

	public override void OnSelect(BaseEventData eventData)
	{
		if(EventSystem.current.currentSelectedGameObject != null) EventSystem.current.SetSelectedGameObject(null);
		EventSystem.current.SetSelectedGameObject(gameObject);
	}
}
