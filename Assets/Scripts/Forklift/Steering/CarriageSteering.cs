using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ForkliftComponent))]
public class CarriageSteering : MonoBehaviour
{

    public ForkliftCarriageSettings forkliftSettings;
    public GameObject masztRuchomaCzesc;
    public float masztOffset;
    Vector3 masztDefaultLoc;
    ForkliftComponent forkliftComponent;
    CarriageInputSettings inputSettings;
    CarriageLimitsSettings limitsSettings;

    Vector3 karetkaDefaultLocalPosition;
    Vector3 karetkaCurrentLocal;
    float mastDefaultRotation;
    float mastCurrentRotation;




    // Use this for initialization
    void Start()
    {
        forkliftComponent = GetComponent<ForkliftComponent>();

        masztDefaultLoc = masztRuchomaCzesc.transform.localPosition;

        limitsSettings = forkliftSettings.limitsSettings;
        inputSettings = forkliftSettings.inputSettings;

        karetkaDefaultLocalPosition = forkliftComponent.karetka.transform.localPosition;
        mastDefaultRotation = forkliftComponent.maszt.transform.localRotation.x;
    }

    // Update is called once per frame
    public void CarriageMove()
    {
        if (ForkliftController.currentForklift.forkliftSteering.silnikUruchomiony)
        {
            SetCarriageLocation();
            SetMastRotation();
        }
    }
    void SetCarriageLocation()
    {
        karetkaCurrentLocal = forkliftComponent.karetka.transform.localPosition - karetkaDefaultLocalPosition;

        float upDownTransform = inputSettings.UpDownValue;
        float leftRightTransform = inputSettings.LeftRightValue;

        karetkaCurrentLocal += new Vector3(leftRightTransform, upDownTransform, 0);

        float limitedLeftRight = UseLimits(Limits.leftRight, karetkaCurrentLocal.x);
        float limitedUpDown = UseLimits(Limits.downUp, karetkaCurrentLocal.y);

        if (limitedUpDown - masztOffset > 0) masztRuchomaCzesc.transform.localPosition = new Vector3(0, masztDefaultLoc.y + limitedUpDown - masztOffset, 0);


        forkliftComponent.karetka.transform.localPosition = new Vector3(limitedLeftRight, limitedUpDown, 0) + karetkaDefaultLocalPosition;

    }
    void SetMastRotation()
    {
        mastCurrentRotation = forkliftComponent.maszt.transform.localRotation.x - mastDefaultRotation;

        float mastRotate = inputSettings.rotationValue;

        mastCurrentRotation += mastRotate;

        float limitedRotation = UseLimits(Limits.forwardBackward, mastCurrentRotation);

        forkliftComponent.maszt.transform.localRotation = new Quaternion(limitedRotation, 0, 0, forkliftComponent.maszt.transform.localRotation.w);
    }
    public float UseLimits(Limits limits, float value)
    {
        float result = 0;
        switch (limits)
        {
            case Limits.downUp:
                if (value > limitsSettings.upLimit) result = limitsSettings.upLimit;
                else if (value < limitsSettings.downLimit) result = limitsSettings.downLimit;
                else result = value;
                break;
            case Limits.leftRight:
                if (value > limitsSettings.leftRightLimit) result = limitsSettings.leftRightLimit;
                else if (value < -limitsSettings.leftRightLimit) result = -limitsSettings.leftRightLimit;
                else result = value;
                break;
            case Limits.forwardBackward:
                if (value > limitsSettings.forwardDegreeLimit / 360f) result = limitsSettings.forwardDegreeLimit / 360f;
                else if (value < limitsSettings.backwardDegreeLimit / 360f) result = limitsSettings.backwardDegreeLimit / 360f;
                else result = value;
                break;
        }

        return result;
    }

    public enum Limits
    {
        leftRight,
        downUp,
        forwardBackward
    }
}
