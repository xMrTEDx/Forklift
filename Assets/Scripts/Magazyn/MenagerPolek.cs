﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenagerPolek : MonoBehaviour
{

    public Polka[] polki;
    [Header("Parametry")]
    [Range(0, 1)]
    public float PrawdopodobienstwoPajawieniaPalety;

    [Header("Prefaby palet")]
    public GameObject[] palety;
    public GameObject placeMarker;

    public void Prepare()
    {
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
                    }
            }
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

        int randomMiejsce = Random.Range(0, miejscaNaPalety.Count);

        GameManager.Instance.QuestsSystem.currentQuest.quest.currentObject = miejscaNaPalety[randomMiejsce].paleta;

        miejscaNaPalety[randomMiejsce].paleta = null;
        miejscaNaPalety[randomMiejsce].CzyWolne = true;

        Instantiate(placeMarker, miejscaNaPalety[randomMiejsce].Miejsce);
    }
}
