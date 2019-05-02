using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaitForSecond : MonoBehaviour
{

    public UnityEvent e_AfterTimeAction;

    public void WaitForSeconds(float time)
    {
        if (gameObject.activeSelf)
            StartCoroutine(WaitForSecondsCourotine(time));
    }
    IEnumerator WaitForSecondsCourotine(float time)
    {
        float timer = 0;
        while (timer < time)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        e_AfterTimeAction.Invoke();
    }
}
