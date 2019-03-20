using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LerpSystem : MonoBehaviour
{

    Coroutine movement;
    public LerpController currentLerpPoint;
    public LerpController startLerpPoint;


    public void Init()
    {
        if(startLerpPoint != null) startLerpPoint.CameraLerpTo();
    }

    public void CameraLerpTo(UnityEvent AfterLerpAction, UnityEvent AfterLerpAction2, float speed, LerpController target)
    {
        if (currentLerpPoint == target && movement == null)
        {
            Debug.Log("same lerp point");
            if (AfterLerpAction != null) AfterLerpAction.Invoke();
            if (AfterLerpAction2 != null) AfterLerpAction2.Invoke();
        }
        else
        {
            if(movement != null)
            Debug.Log("movement -------");
            Debug.Log("different lerp point");
            if (movement != null) StopCoroutine(movement);
            GameManager.Instance.PlayerStatesSystem.SetPlayerState("LerpTo");
            currentLerpPoint = target;

            movement = StartCoroutine(SetCameraTransform(AfterLerpAction, AfterLerpAction2, speed, target));
        }

    }

    IEnumerator SetCameraTransform(UnityEvent AfterLerpAction, UnityEvent AfterLerpAction2, float speed, LerpController target)
    {
        if (Camera.main)
        {
            //GameObject prevMainCamera = Camera.main.gameObject;
            //GameObject tmpCamera = Object.Instantiate(Camera.main.gameObject);
            //tmpCamera.GetComponent<CameraComponent>().SwitchCamera();

            //prevMainCamera.SetActive(false);



            Vector3 startPosition = Camera.main.transform.position;
            Quaternion startRotation = Camera.main.transform.rotation;

            float hlp = 0;
            while (hlp < 1)
            {
                hlp += speed * Time.deltaTime;

                Camera.main.transform.rotation = Quaternion.Lerp(startRotation, target.transform.rotation, hlp);
                Camera.main.transform.position = Vector3.Lerp(startPosition, target.transform.position, hlp);

                yield return null;
            }

            Camera.main.transform.SetParent(target.transform, true);
            //Camera.main.transform.localRotation = new Quaternion(0, 0, 0, 0);
            //Camera.main.transform.localPosition = Vector3.zero;

            if (AfterLerpAction != null) AfterLerpAction.Invoke();
            if (AfterLerpAction2 != null) AfterLerpAction2.Invoke();

            movement = null;

            //Destroy(tmpCamera);
        }
    }
}
