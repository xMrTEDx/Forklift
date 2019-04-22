using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class StatesSystem : MonoBehaviour
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

                if (st == States.forklift && MainPlayer.currentPlayer != null)
                    MainPlayer.currentPlayer.DisablePlayer();
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
        if (gameState == GameStates.game)
        {
            GameManager.Instance.GUIcontroller.pauseMenuManager.InputListener();

            if (playerState == States.walking)
            {
                MainPlayer.currentPlayer.firstPersonController.PlayerCameraMove();
            }
            if (playerState == States.forklift)
            {
                if (ForkliftController.currentForklift)
                    {
                        ForkliftController.currentForklift.ForkliftSteering();
                        if(!ForkliftController.currentForklift) Debug.Log("Elo nie ma wozka");
                        if(!ForkliftController.currentForklift.forkliftComponent) Debug.Log("Elo nie ma componentow");
                        if(!ForkliftController.currentForklift.forkliftComponent.exitForkliftController) Debug.Log("Elo nie ma exit componentu");
                        ForkliftController.currentForklift.forkliftComponent.exitForkliftController.InputListener();
                    }
            }
        }



        if (gameState == GameStates.quests && (playerState != States.none || playerState == States.lerpTo))
        {
            GameManager.Instance.QuestsSystem.InputListener();
        }
        if (gameState == GameStates.pressanykey)
        {
            GameManager.Instance.GUIcontroller.pressAnyKeyController.InputListener();
        }


    }
    void FixedUpdate()
    {
        if (playerState == States.walking)
            MainPlayer.currentPlayer.firstPersonController.PlayerWalking();
    }

    public enum States
    {
        none,
        walking,
        playerAnimation,
        forklift,
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
