using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PressAnyKeyController : MonoBehaviour
{

    public UnityEvent AfterPressAction;
    public LerpController lerpController;
    public Text text;

    public void Init()
    {
        UnityEvent e = new UnityEvent();
        e.AddListener(() =>
        {
			GameManager.Instance.GUIcontroller.mainMenuController.ShowMainMenu(1);
        });

		ShowPressAnyKeyScreen(e);
    }

    public void ShowPressAnyKeyScreen(UnityEvent afterPressAction)
    {
        GameManager.Instance.PlayerStatesSystem.SetGameState("pressanykey");

        //lerpController.CameraLerpTo();

        AfterPressAction = afterPressAction;

        ShowText();
    }
    public void InputListener()
    {
        if (Input.anyKeyDown)
        {
            AfterPressAction.Invoke();
            HideText();
        }
    }
    private void ShowText()
    {
        text.gameObject.SetActive(true);
    }
    private void HideText()
    {
        text.gameObject.SetActive(false);
    }

}
