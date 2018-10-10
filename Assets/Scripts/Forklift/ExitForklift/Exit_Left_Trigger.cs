using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_Left_Trigger : MonoBehaviour
{
    int left_colliders = 0;
    bool result;
    public ExitForkliftController exitForkliftController;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player" && other.tag != "MainCamera")
            left_colliders++;
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player" && other.tag != "MainCamera")
            left_colliders--;
    }
    public bool anyCollidersInsideTrigger()
    {
        result =  left_colliders == 0 ? true : false;
        return result;
    }
}
