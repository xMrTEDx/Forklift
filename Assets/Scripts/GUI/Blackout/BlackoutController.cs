using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackoutController : MonoBehaviour
{

    public Image blackScreen;

	public void Init()
	{
		gameObject.SetActive(true);
		HideBlackout(0.3f);
	}

    public void HideBlackout() { HideBlackout(1); }
    public void HideBlackout(float speed)
    {
        StartCoroutine(HideBlackoutCourotine(speed));
    }
    IEnumerator HideBlackoutCourotine(float speed)
    {
        while (blackScreen.color.a > 0)
        {
            yield return null;
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, blackScreen.color.a - Time.deltaTime * speed);
        }
    }
    public void ShowBlackout() { ShowBlackout(1); }
    public void ShowBlackout(float speed)
    {
        StartCoroutine(ShowBlackoutCourotine(speed));
    }

    IEnumerator ShowBlackoutCourotine(float speed)
    {
        while (blackScreen.color.a < 0)
        {
            yield return null;
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, blackScreen.color.a + Time.deltaTime * speed);
        }
    }
}
