using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuWindow : Window
{

    MainMenuController mainMenuController;
    public LerpController lerpTo;
    public void Init(MainMenuController mmController)
    {
        mainMenuController = mmController;
    }
    public override void EnableWindow()
    {
        base.EnableWindow();
        mainMenuController.CurrentWindow = this;
        if (mainMenuController.CurrentLerpPoint != lerpTo)
        {
            mainMenuController.CurrentLerpPoint = lerpTo;
            lerpTo.CameraLerpTo();
        }
    }
}
