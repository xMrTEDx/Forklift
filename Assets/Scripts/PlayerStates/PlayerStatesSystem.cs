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
    public GameStates gameState = GameStates.none;
    public GameStates GameState
    {
        get { return gameState; }
    }

    public void SetPlayerState(string state)
    {
        foreach (States st in (States[])System.Enum.GetValues(typeof(States)))
        {
            if (string.Compare(st.ToString(), state, true) == 0)
            {
                playerState = st;
                Debug.Log("Set player state to: " + st.ToString());
            }
        }

        GameManager.Instance.IIsystem.RefreshIIvisible();
    }
    public void SetGameState(string state)
    {
        foreach (GameStates st in (GameStates[])System.Enum.GetValues(typeof(GameStates)))
        {
            if (string.Compare(st.ToString(), state, true) == 0)
            {
                gameState = st;
                Debug.Log("Set player state to: " + st.ToString());
            }
        }
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
            if (ForkliftController.currentForklift)
                ForkliftController.currentForklift.ForkliftStay();
        }
        if (playerState == States.forkliftSteering)
        {
            if (ForkliftController.currentForklift)
                ForkliftController.currentForklift.ForkliftSteering();
        }




        if (gameState == GameStates.quests && (playerState != States.none || playerState == States.lerpTo))
        {
            GameManager.Instance.QuestsSystem.InputListener();
        }
        if(gameState == GameStates.pressanykey)
        {
            GameManager.Instance.GUIcontroller.pressAnyKeyController.InputListener();
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
        lerpTo
    }
    public enum GameStates
    {
        none,
        mainmenu,
        quests,
        game,
        pressanykey
    }

}
