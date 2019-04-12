using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoBoxManager : MonoBehaviour
{
	public Text text;
	public Button closeButton;
    public void ShowInfo(string message)
    {
        text.text = message;
        gameObject.SetActive(true);
        Time.timeScale = 0;
		closeButton.Select();
    }
    public void HideInfo()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
	public void Init()
	{
		gameObject.SetActive(false);
	}
}
