using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoBoxSimple : MonoBehaviour
{

    [TextArea]
    public string message;

	public void ShowInfo()
	{
		if(gameObject.activeSelf)
		{
			GameManager.Instance.GUIcontroller.InfoBoxManager.ShowInfo(message);
			gameObject.SetActive(false);
		}
	}
}
