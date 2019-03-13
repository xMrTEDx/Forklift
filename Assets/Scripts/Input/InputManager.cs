using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InputManager : MonoBehaviour
{

    [Header("ZdefiniowaneInputy")]

    public List<SimpleInput> listaInputow;


    ////////////////////////////
    // WYLICZENIA //////////////
    ////////////////////////////

    public enum InputAction
    {
        menuZatwierdz,
        menuPowrot,
        menuPauza,
        interakcja,
        hamulecReczny,
        swiatla,
        klakson,
        zaplon
    }

    ////////////////////////////
    // METODY //////////////////
    ////////////////////////////

    public bool GetKeyDown(InputAction inputAction)
    {
        bool keyDown = false;

        foreach (var item in listaInputow)
        {
            if (item.inputAction == inputAction)
            {
                foreach (var button in item.przyciski)
                {
                    if (Input.GetKeyDown(button)) keyDown = true;
                }
                foreach (var axis in item.osie)
                {
                    if (Input.GetAxis(axis) > 0.05f) keyDown = true;
                }
            }
        }
        return keyDown;
    }

    public float GetAxis(InputAction inputAction)
    {
        float value = 0;

        foreach (var item in listaInputow)
        {
            if (item.inputAction == inputAction)
            {
                foreach (var button in item.przyciski)
                {
                    if (Input.GetKeyDown(button)) value = 1;
                    break;
                }
                foreach (var axis in item.osie)
                {
                    value = Input.GetAxis(axis);
                }
            }
        }
        return value;
    }
/* 
    public bool GetKeyUp(InputAction inputAction)
    {
         bool keyUp = true;

        foreach (var item in listaInputow)
        {
            if (item.inputAction == inputAction)
            {
                foreach (var button in item.przyciski)
                {
                    if (Input.GetKeyDown(button)) keyUp = false;
                }
                foreach (var axis in item.osie)
                {
                    if (Input.GetAxis(axis) > 0.05f) keyUp = false;
                }
            }
        }
        return keyUp;
    }
*/

}

