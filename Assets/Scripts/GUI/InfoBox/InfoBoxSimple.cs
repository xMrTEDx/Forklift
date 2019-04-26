using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InfoBoxSimple : MonoBehaviour
{

    [TextArea]
    public string message;

	public UnityEvent e_OnCloseInfoBoxAction;

	public void ShowInfo()
	{
		if(gameObject.activeSelf)
		{
			GameManager.Instance.GUIcontroller.InfoBoxManager.ShowInfo(this);
			gameObject.SetActive(false);
		}
	}
}
