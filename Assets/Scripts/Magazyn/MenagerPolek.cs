using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenagerPolek : MonoBehaviour
{

    public Polka[] polki;
    [Header("Parametry")]
    [Range(0, 1)]
    public float PrawdopodobienstwoPajawieniaPalety;

    [Header("Prefaby palet")]
    public GameObject[] palety;
    public GameObject placeMarker;
    private GameObject currentMarker;
    public UnityEvent e_finishQuest;

    public void Prepare()
    {
        int liczbaPalet = 0;
        foreach (var polka in polki)
        {
            foreach (var miejsce in polka.miejscaNaPalety)
            {
                if (miejsce.CzyWolne == true)
                    if (Random.Range(1, 100) <= PrawdopodobienstwoPajawieniaPalety * 100)
                    {
                        GameObject paleta = Instantiate(palety[Random.Range(0, palety.Length)], miejsce.Miejsce, false);
                        paleta.transform.localRotation = Quaternion.identity;
                        paleta.transform.localPosition = Vector3.zero;
                        paleta.GetComponent<Rigidbody>().centerOfMass = Vector3.zero;
                        //paleta.transform.localScale = new Vector3(1,1,1);
                        miejsce.CzyWolne = false;

                        miejsce.paleta = paleta;

                        liczbaPalet++;
                    }
            }
        }

        if (liczbaPalet == 0)
        {
            GameObject paleta = Instantiate(palety[Random.Range(0, palety.Length)], polki[0].miejscaNaPalety[0].Miejsce, false);
            paleta.transform.localRotation = Quaternion.identity;
            paleta.transform.localPosition = Vector3.zero;
            paleta.GetComponent<Rigidbody>().centerOfMass = Vector3.zero;
            //paleta.transform.localScale = new Vector3(1,1,1);
            polki[0].miejscaNaPalety[0].CzyWolne = false;

            polki[0].miejscaNaPalety[0].paleta = paleta;

            liczbaPalet++;
        }

        RandomObject();
    }

    public void RandomObject()
    {
        List<Polka.MiejsceNaPalete> miejscaNaPalety = new List<Polka.MiejsceNaPalete>();
        foreach (var polka in polki)
        {
            foreach (var miejsce in polka.miejscaNaPalety)
            {
                if (miejsce.CzyWolne == false)
                {
                    miejscaNaPalety.Add(miejsce);
                }
            }
        }

        if (miejscaNaPalety.Count > 0)
        {

            int randomMiejsce = Random.Range(0, miejscaNaPalety.Count);

            GameManager.Instance.QuestsSystem.currentQuest.quest.currentObject = miejscaNaPalety[randomMiejsce].paleta.GetComponentInChildren<BoxCollider>().gameObject;

            miejscaNaPalety[randomMiejsce].paleta = null;
            miejscaNaPalety[randomMiejsce].CzyWolne = true;

            currentMarker = Instantiate(placeMarker, miejscaNaPalety[randomMiejsce].Miejsce);
        }
        else
        {
            e_finishQuest.Invoke();
        }
    }
    public void ArriveObject()
    {
        if (GameManager.Instance.QuestsSystem.currentQuest.quest.currentObject != null)
        {
            Destroy(GameManager.Instance.QuestsSystem.currentQuest.quest.currentObject.GetComponentInParent<Rigidbody>().gameObject);
        }
        if (currentMarker != null)
        {
            Destroy(currentMarker);
        }

        RandomObject();
    }
}
