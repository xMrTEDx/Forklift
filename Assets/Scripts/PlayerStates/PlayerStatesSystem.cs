using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerStatesSystem : MonoBehaviour
{
    public States playerState = States.none;
	public States PlayerState
	{
		get { return playerState; }
	}

    public void SetPlayerState(string state)
	{
        foreach (States st in (States[]) System.Enum.GetValues(typeof(States)))
        {
            if(st.ToString() == state)
            {
                playerState = st;
            }
        }
		
        GameManager.Instance.IIsystem.RefreshIIvisible();
	}

    public void Init()
    {
        SetPlayerState("none");
    }

    void Update()
    {
        if (playerState == States.walking)
        {
            MainPlayer.Instance.firstPersonController.PlayerCameraMove();
        }
        if (playerState == States.forklift)
        {
            if(ForkliftController.currentForklift)
            ForkliftController.currentForklift.ForkliftStay();
        }
        if (playerState == States.forkliftSteering)
        {
            if(ForkliftController.currentForklift)
            ForkliftController.currentForklift.ForkliftSteering();
        }
        
    }
    void FixedUpdate()
    {
        if (playerState == States.walking)
            MainPlayer.Instance.firstPersonController.PlayerWalking();
    }

    public enum States
	{
        none,
		walking,
        playerAnimation,
		forklift,
        forkliftSteering,
        lerpTo,
        menu
	}
    
}
