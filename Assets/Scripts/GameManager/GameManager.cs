using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public InteractionIndicatorSystem IIsystem;
	public PlayerStatesSystem PlayerStatesSystem;
	public InputManager InputManager;

	public GUIcontroller GUIcontroller;

    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
	{
		instance = this;
		IIsystem.Init();
		PlayerStatesSystem.Init();
		GUIcontroller.Init();
	}
}
