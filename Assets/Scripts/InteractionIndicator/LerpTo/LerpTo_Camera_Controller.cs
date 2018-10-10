using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LerpTo_Camera_Controller : MonoBehaviour
{

    [Range(0.1f, 6f)]
    public float lerpSpeed = 2.2f;
    public UnityEvent e_OnLerpFinished = new UnityEngine.Events.UnityEvent();

    public void CameraLerpTo()
    {
        //Debug.Log("lerp");

        PlayerStatesSystem.Instance.SetPlayerState("LerpTo");

        StartCoroutine(SetCameraTransform());
    }
    IEnumerator SetCameraTransform()
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
                hlp += lerpSpeed * Time.deltaTime;

                Camera.main.transform.rotation = Quaternion.Lerp(startRotation, gameObject.transform.rotation, hlp);
                Camera.main.transform.position = Vector3.Lerp(startPosition, gameObject.transform.position, hlp);

                yield return null;
            }

            Camera.main.transform.SetParent(this.transform);
            Camera.main.transform.localRotation = new Quaternion(0, 0, 0, 0);
            Camera.main.transform.localPosition = Vector3.zero;

            e_OnLerpFinished.Invoke();


            //Destroy(tmpCamera);
        }

    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, (transform.position + transform.forward * 5));
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }
}
