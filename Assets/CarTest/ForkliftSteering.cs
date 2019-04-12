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
    public float brakeForce = 2000f;
    public float steeringSpeed = 1f;
    public float steeringInput = 0f;

    public Gear gear = Gear.d;

    private Rigidbody rb;

    public Text speedText;
    [Space]
    [Header("Kierownica")]

    public GameObject steeringWheel;
    public float przelozenieKierownicy = 3f;

    public float holdBreakTimer = 0f;
    public float timeToSetReverse = 1f;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfGravity.localPosition;
        SetsteeringWheelRotation();
    }

    public float Speed()
    {
        return rb.velocity.magnitude;
    }

    public float Rpm()
    {
        return wheelRL.rpm;
    }
    void SetGearN()
    {
        gear = Gear.d;
    }
    void SetGearD()
    {
        gear = Gear.d;
    }
    void SetGearR()
    {
        gear = Gear.r;
    }

    public void SteeringForklift()
    {

        if (speedText != null)
            speedText.text = "Speed: " + Speed().ToString("f0") + " km/h";

        //Debug.Log ("Speed: " + (wheelRR.radius * Mathf.PI * wheelRR.rpm * 60f / 1000f) + "km/h    RPM: " + wheelRL.rpm);

        float gazHamulecInput = Input.GetAxis("wozekGazHamulec");

        if (gear == Gear.r) gazHamulecInput = -gazHamulecInput;
        if (gazHamulecInput >= 0)
        {
            holdBreakTimer = 0;
            float scaledTorque = Input.GetAxis("wozekGazHamulec") * torque;

            if (wheelRL.rpm < idealRPM)
                scaledTorque = Mathf.Lerp(scaledTorque, scaledTorque, wheelRL.rpm / idealRPM);
            else
                scaledTorque = Mathf.Lerp(scaledTorque, 0, (wheelRL.rpm - idealRPM) / (maxRPM - idealRPM));

            //DoRollBar(wheelFR, wheelFL);
            //DoRollBar(wheelRR, wheelRL);


            wheelFR.motorTorque = scaledTorque;
            wheelFL.motorTorque = scaledTorque;
            wheelRL.motorTorque = scaledTorque;
            wheelRR.motorTorque = scaledTorque;



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

            rb.AddForce(-rb.velocity * gazHamulecABS * brakeForce);

            if (Speed() < 0.02f) holdBreakTimer += Time.deltaTime;
            else holdBreakTimer = 0;
        }
        steeringInput += Input.GetAxis("wozekPrawoLewo") * Time.deltaTime * steeringSpeed;
        steeringInput = Normalize(steeringInput);

        wheelRR.steerAngle = -steeringInput;
        wheelRL.steerAngle = -steeringInput;

        //Debug.Log(wheelFR.rpm + "\t" + wheelFL.rpm + "\t" + wheelRR.rpm + "\t" + wheelRL.rpm);

        SetsteeringWheelRotation();

        if (holdBreakTimer > timeToSetReverse)
        {
            holdBreakTimer = 0;
            gear = gear == Gear.d ? Gear.r : Gear.d;
        }
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
    void SetsteeringWheelRotation()
    {
        steeringWheel.transform.localRotation = Quaternion.Euler(0, steeringInput * przelozenieKierownicy, 0);

    }

    public enum Gear
    {
        d,
        r
    }

}
