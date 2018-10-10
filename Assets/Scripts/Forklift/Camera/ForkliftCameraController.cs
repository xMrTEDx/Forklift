using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkliftCameraController : MonoBehaviour {

	private GameObject forkliftCamera;
	public GameObject forkliftDownUp_Transform;

	[Range(0.1f,2f)]
	public float sensivity = 0.5f;

	public void RotateForkliftCamera()
	{
		gameObject.transform.localRotation = new Quaternion(gameObject.transform.localRotation.x,gameObject.transform.localRotation.y + Input.GetAxis("Mouse X")*sensivity/20,gameObject.transform.localRotation.z,gameObject.transform.localRotation.w);
		
		forkliftDownUp_Transform.transform.localRotation = new Quaternion(forkliftDownUp_Transform.transform.localRotation.x - Input.GetAxis("Mouse Y")*sensivity/20,forkliftDownUp_Transform.transform.localRotation.y,forkliftDownUp_Transform.transform.localRotation.z,forkliftDownUp_Transform.transform.localRotation.w);
		
		

	}

}
