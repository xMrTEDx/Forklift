using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkliftCameraController : MonoBehaviour
{

    private GameObject forkliftCamera;
    public GameObject forkliftDownUp_Transform;
    float xAxis = 0;
    float yAxis = 0;

    [Range(0.1f, 5f)]
    public float sensivityX = 2f;
    [Range(0.1f, 5f)]
    public float sensivityY = 2f;

    public void RotateForkliftCamera()
    {
        xAxis += Input.GetAxis("Mouse X");
        yAxis += -Input.GetAxis("Mouse Y");
		yAxis = NormalizeValue(yAxis);
        gameObject.transform.localRotation = Quaternion.Euler(0, xAxis * sensivityX, 0);// new Quaternion(gameObject.transform.localRotation.x,gameObject.transform.localRotation.y + Input.GetAxis("Mouse X")*sensivity/20,gameObject.transform.localRotation.z,gameObject.transform.localRotation.w);

        forkliftDownUp_Transform.transform.localRotation = Quaternion.Euler(yAxis * sensivityY, 0, 0);// new Quaternion(forkliftDownUp_Transform.transform.localRotation.x - Input.GetAxis("Mouse Y")*sensivity/20,forkliftDownUp_Transform.transform.localRotation.y,forkliftDownUp_Transform.transform.localRotation.z,forkliftDownUp_Transform.transform.localRotation.w);
    }
    float NormalizeValue(float value)
    {
        if (value > 45) return 45;
        else if (value < -45) return -45;
        else return value;
    }
}
