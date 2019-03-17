using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LerpController : MonoBehaviour
{

    [Range(0.1f, 6f)]
    public float lerpSpeed = 2.2f;
    public UnityEvent e_OnLerpFinished = new UnityEngine.Events.UnityEvent();

    public void CameraLerpTo()
    {
        GameManager.Instance.lerpSystem.CameraLerpTo(e_OnLerpFinished, null, lerpSpeed, this);
    }
    public void CameraLerpTo(UnityEvent afterLerpAction)
    {
        GameManager.Instance.lerpSystem.CameraLerpTo(e_OnLerpFinished, afterLerpAction, lerpSpeed, this);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, (transform.position + transform.forward * 5));
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }
}
