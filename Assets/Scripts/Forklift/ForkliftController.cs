using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkliftController : MonoBehaviour
{

    public static ForkliftController currentForklift;
    ForkliftComponent forkliftComponent;
    CarriageSteering carriageSteering;
    
	Quaternion cameraDefaultRot;
    // Quaternion cameraDefaultRotXZ;

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
        carriageSteering.ForkliftSteering();
        forkliftComponent.forkliftCameraController.RotateForkliftCamera();
        
    }
    public void ForkliftStay()
    {
        forkliftComponent.forkliftCameraController.RotateForkliftCamera();
    }


    public void GetOnForklift()
    {
        currentForklift = this;
        //forkliftComponent.forkliftIIsystem.SetForkliftState("main");

        //forkliftComponent.forkliftCameraController.forkliftCamera.GetComponent<Camera>().enabled = true;

        // Transform tmpTransform = forkliftCameraController.forkliftCamera.transform;

        // forkliftCameraController.forkliftCamera = Instantiate(Camera.main.gameObject);
        // forkliftCameraController.forkliftCamera.transform.position = tmpTransform.position;
        // forkliftCameraController.forkliftCamera.transform.rotation = tmpTransform.rotation;


        //forkliftComponent.forkliftCameraController.forkliftCamera.tag = "MainCamera";
        //Camera.SetupCurrent(forkliftComponent.forkliftCameraController.forkliftCamera.GetComponent<Camera>());
        //Debug.Log(Camera.main);

        //MainPlayer.Instance.DisablePlayer();



        PlayerStatesSystem.Instance.SetPlayerState("forklift");
    }
    public void GetDownForklift()
    {
		forkliftComponent.forkliftCameraController.transform.localRotation = cameraDefaultRot;

        //forkliftComponent.forkliftIIsystem.DisableAllII();
		
        // forkliftComponent.forkliftCameraController.gameObject.transform.rotation = cameraDefaultRotY;
        // forkliftComponent.forkliftCameraController.GetComponentInChildren<Camera>().gameObject.transform.rotation = cameraDefaultRotXZ;
        //forkliftComponent.forkliftCameraController.forkliftCamera.tag = "Untagged";
        //PlayerStatesSystem.Instance.SetPlayerState("walking");
        //MainPlayer.Instance.EnablePlayer();
        //forkliftComponent.forkliftCameraController.forkliftCamera.GetComponent<Camera>().enabled = false;

        currentForklift = null;
    }


}
