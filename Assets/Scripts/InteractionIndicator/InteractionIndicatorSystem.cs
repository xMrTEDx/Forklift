using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States = PlayerStatesSystem.States;

public class InteractionIndicatorSystem : Singleton<InteractionIndicatorSystem> {

    public List<GameObject> interactionIndicators;
	
	public void SetIIvisibleFromPlayerState()
    {
        if(PlayerStatesSystem.Instance){
            foreach (var item in interactionIndicators)
            {
                bool flag = false;
                States[] IIstates = item.GetComponent<InteractionIndicatorControl>().playerStates;
                foreach(var i in IIstates)
                {
                    if(i==PlayerStatesSystem.Instance.PlayerState)
                    flag=true;
                }
                if(flag==true) item.SetActive(true);
                else item.SetActive(false);

                

            }
        }
        
    }
    public void FindAllIIfromScene()
    {
        GameObject[] II =  GameObject.FindGameObjectsWithTag("InteractionIndicator");
        interactionIndicators.Clear();
        interactionIndicators.AddRange(II);
    }
}
