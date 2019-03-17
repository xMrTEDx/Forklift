using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaitForPessScreen : MonoBehaviour
{

    public int secondsToShowScreen;
    float counter = 0;
    public UnityEvent OnTimeEndAction;
    public UnityEvent AfterAnyKeyPressed;
    void Update()
    {
        if (Input.anyKeyDown) counter = 0;
        counter += Time.deltaTime;
        if (counter > secondsToShowScreen)
        {
            counter = 0;
            OnTimeEndAction.Invoke();
            GameManager.Instance.GUIcontroller.pressAnyKeyController.ShowPressAnyKeyScreen(AfterAnyKeyPressed);
        }
    }
}
