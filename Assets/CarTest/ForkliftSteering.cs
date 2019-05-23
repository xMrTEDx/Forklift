using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;

public class ForkliftSteering : MonoBehaviour
{

    public float predkoscDocelowa = 500f;
    public float predkoscMaksymalna = 1000f;

    public Transform centerOfGravity;

    public WheelCollider koloPrzodPrawe;
    public WheelCollider koloPrzodLewe;
    public WheelCollider koloTylPrawe;
    public WheelCollider koloTylLewe;
    public float katObrotuKol = 6f;
    public float silaPrzyspieszenia = 25f;
    public float silaHamowaniaKol = 100f;
    public float dodatkowaSilaHamowania = 2000f;
    public float szybkoscSkrecania = 1f;
    public float steeringInput = 0f;

    public bool silnikUruchomiony = false;

    public Bieg bieg = Bieg.d;

    private Rigidbody rb;

    //public Text speedText;
    [Space]
    [Header("Kierownica")]

    public GameObject kierownica;
    public float przelozenieKierownicy = 3f;

    public float czasZatrzymania = 0f;
    public float czasDoZmianyKierunkuJazdy = 1f;

    [Header("Pozwolenia")]
    public bool mozliwoscJazdy = true;
    public bool mozliwoscKierowania = true;
    public bool mozliwoscPoruszaniaDziwgniami = true;
    public bool mozliwoscUruchomieniaSilnika = true;

    [Space, Header("Eventy")]
    public UnityEvent WlaczenieSilnikaAction;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfGravity.localPosition;
        UstawPolozenieKierownicy();
    }

    public float Speed()
    {
        return rb.velocity.magnitude;
    }

    public float Rpm()
    {
        return koloTylLewe.rpm;
    }
    void SetGearN()
    {
        bieg = Bieg.d;
    }
    void SetGearD()
    {
        bieg = Bieg.d;
    }
    void SetGearR()
    {
        bieg = Bieg.r;
    }

    public void SterowanieWozkiem()
    {

        //if (speedText != null)
        //    speedText.text = "Speed: " + Speed().ToString("f0") + " km/h";

        if (mozliwoscUruchomieniaSilnika && (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.JoystickButton3)))
        {
            silnikUruchomiony = !silnikUruchomiony;
            WlaczenieSilnikaAction.Invoke();
        }


        if (mozliwoscJazdy)
        {
            float gazHamulecInput = Input.GetAxis("wozekGazHamulec");

            if (bieg == Bieg.r) gazHamulecInput = -gazHamulecInput;
            if (silnikUruchomiony && gazHamulecInput >= 0)
            {
                czasZatrzymania = 0;
                float scaledTorque = Input.GetAxis("wozekGazHamulec") * silaPrzyspieszenia;

                if (koloTylLewe.rpm < predkoscDocelowa)
                    scaledTorque = Mathf.Lerp(scaledTorque, scaledTorque, koloTylLewe.rpm / predkoscDocelowa);
                else
                    scaledTorque = Mathf.Lerp(scaledTorque, 0, (koloTylLewe.rpm - predkoscDocelowa) / (predkoscMaksymalna - predkoscDocelowa));


                koloPrzodPrawe.motorTorque = scaledTorque;
                koloPrzodLewe.motorTorque = scaledTorque;
                koloTylLewe.motorTorque = scaledTorque;
                koloTylPrawe.motorTorque = scaledTorque;



                koloPrzodPrawe.brakeTorque = 0;
                koloPrzodLewe.brakeTorque = 0;
                koloTylPrawe.brakeTorque = 0;
                koloTylLewe.brakeTorque = 0;


            }
            else
            {
                float gazHamulecABS = Mathf.Abs(gazHamulecInput);
                koloPrzodPrawe.brakeTorque = silaHamowaniaKol * gazHamulecABS;
                koloPrzodLewe.brakeTorque = silaHamowaniaKol * gazHamulecABS;
                koloTylPrawe.brakeTorque = silaHamowaniaKol * gazHamulecABS;
                koloTylLewe.brakeTorque = silaHamowaniaKol * gazHamulecABS;

                rb.AddForce(-rb.velocity * gazHamulecABS * dodatkowaSilaHamowania);

                if (silnikUruchomiony)
                {
                    if (Speed() < 0.02f) czasZatrzymania += Time.deltaTime;
                    else czasZatrzymania = 0;
                }
            }
        }

        if (!silnikUruchomiony)
        {
            koloPrzodPrawe.brakeTorque = silaHamowaniaKol * 0.2f;
            koloPrzodLewe.brakeTorque = silaHamowaniaKol * 0.2f;
            koloTylPrawe.brakeTorque = silaHamowaniaKol * 0.2f;
            koloTylLewe.brakeTorque = silaHamowaniaKol * 0.2f;
        }

        if (mozliwoscKierowania)
        {
            steeringInput += Input.GetAxis("wozekPrawoLewo") * Time.deltaTime * szybkoscSkrecania;
            steeringInput = OgranicznikObrotuKol(steeringInput);

            koloTylPrawe.steerAngle = -steeringInput;
            koloTylLewe.steerAngle = -steeringInput;
        }


        UstawPolozenieKierownicy();

        if (czasZatrzymania > czasDoZmianyKierunkuJazdy)
        {
            czasZatrzymania = 0;
            bieg = bieg == Bieg.d ? Bieg.r : Bieg.d;
        }

        if (mozliwoscPoruszaniaDziwgniami)
        {
            if (ForkliftController.currentForklift != null)
            {
                float bieg = this.bieg == Bieg.d ? -1 : 1;
                ForkliftController.currentForklift.forkliftComponent.sterowanieDzwigniami.UstawPolozenieDzwigni(bieg);
            }
        }
    }

    float OgranicznikObrotuKol(float value)
    {
        if (value > przelozenieKierownicy) return przelozenieKierownicy;
        else if (value < -przelozenieKierownicy) return -przelozenieKierownicy;
        else return value;
    }
    void UstawPolozenieKierownicy()
    {
        kierownica.transform.localRotation = Quaternion.Euler(0, steeringInput * przelozenieKierownicy, 0);

    }

    public enum Bieg
    {
        d,
        r
    }

}
