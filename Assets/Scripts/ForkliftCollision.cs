using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ForkliftCollision : MonoBehaviour
{

    public UnityEvent e_OnCollisionEnterAction;
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("KOLIZJA: " + other.gameObject.tag);
        if (other.gameObject.tag == "Forklift")
        {
            e_OnCollisionEnterAction.Invoke();
            //gameObject.SetActive(false);
        }
    }
}
