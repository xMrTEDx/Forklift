using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States = StatesSystem.States;

public class InteractionIndicatorSystem : MonoBehaviour
{

    public List<GameObject> interactionIndicators;

    public void Init()
    {
        FindAllIIfromScene();
    }

    public void RefreshIIvisible()
    {
        if (GameManager.Instance.PlayerStatesSystem)
        {
            foreach (var item in interactionIndicators)
            {
                bool flag = false;
                InteractionIndicatorControl IIControl = item.GetComponent<InteractionIndicatorControl>();

                States[] IIstates = IIControl.playerStates;
                foreach (var i in IIstates)
                {
                    if (i == GameManager.Instance.PlayerStatesSystem.PlayerState)
                        flag = true;
                    else break;
                }
                if (flag == true) item.SetActive(true);
                else item.SetActive(false);
            }
        }

    }
    public void FindAllIIfromScene()
    {
        GameObject[] II = GameObject.FindGameObjectsWithTag("InteractionIndicator");
        interactionIndicators.Clear();
        interactionIndicators.AddRange(II);
    }
}
