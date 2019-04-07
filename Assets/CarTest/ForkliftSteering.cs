using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ForkliftSteering : MonoBehaviour
{

    public float idealRPM = 500f;
    public float maxRPM = 1000f;

    public Transform centerOfGravity;

    public WheelCollider wheelFR;
    public WheelCollider wheelFL;
    public WheelCollider wheelRR;
    public WheelCollider wheelRL;
    public float turnRadius = 6f;
    public float torque = 25f;
    public float brakeTorque = 100f;
    public float steeringSpeed = 1f;
    public float steeringInput = 0f;

    private Rigidbody rb;

    public Text speedText;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfGravity.localPosition;

    }

    public float Speed()
    {
        return rb.velocity.magnitude;
    }

    public float Rpm()
    {
        return wheelRL.rpm;
    }

    public void SteeringForklift()
    {

        if (speedText != null)
            speedText.text = "Speed: " + Speed().ToString("f0") + " km/h";

        //Debug.Log ("Speed: " + (wheelRR.radius * Mathf.PI * wheelRR.rpm * 60f / 1000f) + "km/h    RPM: " + wheelRL.rpm);

        float gazHamulecInput = Input.GetAxis("wozekGazHamulec");
        if (gazHamulecInput >= 0)
        {
            float scaledTorque = Input.GetAxis("wozekGazHamulec") * torque;

            if (wheelRL.rpm < idealRPM)
                scaledTorque = Mathf.Lerp(scaledTorque, scaledTorque, wheelRL.rpm / idealRPM);
            else
                scaledTorque = Mathf.Lerp(scaledTorque, 0, (wheelRL.rpm - idealRPM) / (maxRPM - idealRPM));

            //DoRollBar(wheelFR, wheelFL);
            //DoRollBar(wheelRR, wheelRL);



            wheelFR.motorTorque = scaledTorque;
            wheelFL.motorTorque = scaledTorque;


            wheelFR.brakeTorque = 0;
            wheelFL.brakeTorque = 0;
            wheelRR.brakeTorque = 0;
            wheelRL.brakeTorque = 0;
        }
        else
        {
            float gazHamulecABS = Mathf.Abs(gazHamulecInput);
            wheelFR.brakeTorque = brakeTorque * gazHamulecABS;
            wheelFL.brakeTorque = brakeTorque * gazHamulecABS;
            wheelRR.brakeTorque = brakeTorque * gazHamulecABS;
            wheelRL.brakeTorque = brakeTorque * gazHamulecABS;
        }
        steeringInput += Input.GetAxis("Horizontal") * Time.deltaTime * steeringSpeed;
        steeringInput = Normalize(steeringInput);

        wheelRR.steerAngle = -steeringInput;
        wheelRL.steerAngle = -steeringInput;
    }


    /*void DoRollBar(WheelCollider WheelL, WheelCollider WheelR)
    {
        WheelHit hit;
        float travelL = 1.0f;
        float travelR = 1.0f;

        bool groundedL = WheelL.GetGroundHit(out hit);
        if (groundedL)
            travelL = (-WheelL.transform.InverseTransformPoint(hit.point).y - WheelL.radius) / WheelL.suspensionDistance;

        bool groundedR = WheelR.GetGroundHit(out hit);
        if (groundedR)
            travelR = (-WheelR.transform.InverseTransformPoint(hit.point).y - WheelR.radius) / WheelR.suspensionDistance;

        // float antiRollForce = (travelL - travelR) * AntiRoll;

        // if (groundedL)
        // 	gameObject.GetComponent<Rigidbody>().AddForceAtPosition(WheelL.transform.up * -antiRollForce,
        // 	                             WheelL.transform.position); 
        // if (groundedR)
        // 	gameObject.GetComponent<Rigidbody>().AddForceAtPosition(WheelR.transform.up * antiRollForce,
        // 	                             WheelR.transform.position); 
    }
    */
    float Normalize(float value)
    {
        if (value > turnRadius) return turnRadius;
        else if (value < -turnRadius) return -turnRadius;
        else return value;
    }

}
