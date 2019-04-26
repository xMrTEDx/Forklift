using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoBoxManager : MonoBehaviour
{
    public Text text;
    public Button closeButton;
    public void ShowInfo(InfoBoxSimple infoBox)
    {
        text.text = infoBox.message;
        gameObject.SetActive(true);
        Time.timeScale = 0;
        
        closeButton.onClick.RemoveAllListeners();
        closeButton.onClick.AddListener(() => { HideInfo(); infoBox.e_OnCloseInfoBoxAction.Invoke(); });
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
