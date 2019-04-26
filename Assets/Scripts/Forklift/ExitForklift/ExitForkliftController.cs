using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExitForkliftController : MonoBehaviour
{

    public UnityEvent e_Exit_Left = new UnityEvent();
    public UnityEvent e_Exit_Right = new UnityEvent();
    [Space]
    [Space]
    public Exit_Left_Trigger exit_Left_Trigger;
    public Exit_Right_Trigger exit_Right_Trigger;

    public void InputListener()
    {
        //Debug.Log("LEFT: "+exit_Left_Trigger.anyCollidersInsideTrigger()+"     RIGHT: "+exit_Right_Trigger.anyCollidersInsideTrigger());
        if (GameManager.Instance.PlayerStatesSystem.PlayerState == StatesSystem.States.forklift && ForkliftController.currentForklift != null)
        {

            if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.JoystickButton2))
            {
                if (Mathf.Abs(ForkliftController.currentForklift.forkliftSteering.Speed()) <= 0.02f)
                {
                    if (exit_Left_Trigger.anyCollidersInsideTrigger())
                    {
                        e_Exit_Left.Invoke();
                        //ForkliftController.currentForklift.GetDownForklift();
                    }
                }
                else
                    Prompt.Instance.ShowPrompt("Nie możesz wysiąść z wózka podczas jazdy");
            }
            if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.JoystickButton1))
            {
                if (Mathf.Abs(ForkliftController.currentForklift.forkliftSteering.Speed()) <= 0.02f)
                {
                    if (exit_Right_Trigger.anyCollidersInsideTrigger())
                    {
                        e_Exit_Right.Invoke();
                        //ForkliftController.currentForklift.GetDownForklift();
                    }
                }
                else
                    Prompt.Instance.ShowPrompt("Nie możesz wysiąść z wózka podczas jazdy");
            }
        }
    }


}
