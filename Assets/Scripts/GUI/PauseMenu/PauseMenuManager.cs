using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{

    private float m_TimeScaleRef = 1f;
    private bool m_Paused;

    public Window mainWindow;

    public void Init()
    {

    }

    private void MenuOn()
    {
        m_TimeScaleRef = Time.timeScale;
        Time.timeScale = 0f;

        m_Paused = true;
        mainWindow.EnableWindow();
    }


    public void MenuOff()
    {
        Time.timeScale = m_TimeScaleRef;
        m_Paused = false;
        mainWindow.DisableWindow();
    }


    public void OnMenuStatusChange()
    {
        if (!m_Paused)
        {
            MenuOn();
        }
        else
        {
            MenuOff();
        }

        Cursor.visible = m_Paused;
    }


    public void InputListener()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            OnMenuStatusChange();
        }
    }
}
