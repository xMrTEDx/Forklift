using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_Right_Trigger : MonoBehaviour
{
    int right_colliders = 0;
    bool result;
    public ExitForkliftController exitForkliftController;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player" && other.tag != "MainCamera")
            right_colliders++;
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player" && other.tag != "MainCamera")
            right_colliders--;
    }
    public bool anyCollidersInsideTrigger()
    {
        result =  right_colliders == 0 ? true : false;
        return result;
    }
}
