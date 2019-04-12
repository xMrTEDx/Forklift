using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkliftController : MonoBehaviour
{

    public static ForkliftController currentForklift;
    public ForkliftComponent forkliftComponent;
    public CarriageSteering carriageSteering;
    public ForkliftSteering forkliftSteering;
    
	Quaternion cameraDefaultRot;

    void Awake()
    {
        forkliftComponent = GetComponent<ForkliftComponent>();
        carriageSteering = GetComponent<CarriageSteering>();
    }
    void Start()
    {
    	cameraDefaultRot = forkliftComponent.forkliftCameraController.gameObject.transform.rotation;
    }

    public void ForkliftSteering()
    {
        //if(carriageSteering)
        carriageSteering.CarriageMove();
        //if(forkliftSteering)
        forkliftSteering.SteeringForklift();
        //if(forkliftComponent)
        forkliftComponent.forkliftCameraController.RotateForkliftCamera();
        
    }


    public void GetOnForklift()
    {
        currentForklift = this;
        GameManager.Instance.PlayerStatesSystem.SetPlayerState("forklift");
    }
    public void GetDownForklift()
    {
		currentForklift = null;
    }


}
