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

    void Update()
    {
		//Debug.Log("LEFT: "+exit_Left_Trigger.anyCollidersInsideTrigger()+"     RIGHT: "+exit_Right_Trigger.anyCollidersInsideTrigger());
        if (GameManager.Instance.PlayerStatesSystem.PlayerState == StatesSystem.States.forklift)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                if(exit_Left_Trigger.anyCollidersInsideTrigger())
					e_Exit_Left.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                if(exit_Right_Trigger.anyCollidersInsideTrigger())
					e_Exit_Right.Invoke();
            }
        }
    }


}
