using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flockController : MonoBehaviour
{

    public float swimmingSpeed;
    public float swimmingUPSpeed;

    public float maxSwimmingSpeed;
    public float predkoscOpadania;
    public float rotationSpeed;
    public float rotationYSpeed;
    public float distanceToTurnBack = 1f;

    public float sizeMin;
    public float sizeMax;

    public int numberOfMeduza;
    public GameObject MeduzaPrefab;

    public float maxRotation;

    public BoxCollider SwimmingArea;
    public AnimationCurve speedCurve;

    Meduza[] meduzy;

    void Start()
    {
        SpawnMeduza();
    }

    #region spawn meduza
    void SpawnMeduza()
    {
        int dir = 0;
        meduzy = new Meduza[numberOfMeduza];
        for (int i = 0; i < numberOfMeduza; i++)
        {
            meduzy[i] = Instantiate(MeduzaPrefab, SwimmingArea.transform).GetComponent<Meduza>();
            SetRandomPosition(meduzy[i].gameObject);
            SetRandomRotation(meduzy[i].gameObject);
            SetRandomScale(meduzy[i].gameObject);
            SetRandomAnimationSpeed(meduzy[i].GetComponent<Animator>());
            meduzy[i].direction = dir % 2 == 0 ? true : false;
            dir++;
        }
    }
    void SetRandomPosition(GameObject go)
    {
        go.transform.localPosition = new Vector3(Random.Range(-SwimmingArea.size.x / 2, SwimmingArea.size.x / 2), Random.Range(-SwimmingArea.size.y / 2, SwimmingArea.size.y / 2), Random.Range(-SwimmingArea.size.z / 2, SwimmingArea.size.z / 2));
    }
    void SetRandomRotation(GameObject go)
    {
        go.transform.localRotation = Quaternion.Euler(Random.Range(0, maxRotation), Random.Range(0, 360), 0);
    }
    void SetRandomScale(GameObject go)
    {
        float scale = Random.Range(sizeMin, sizeMax);
        go.transform.localScale = new Vector3(scale, scale, scale);
    }
    void SetRandomAnimationSpeed(Animator animator)
    {
        animator.speed = Random.Range(0.9f, 1.1f);
    }
    #endregion

    void Update()
    {
        MeduzaMovement();
        for (int i = 0; i < meduzy.Length; i++)
        {
            float value = meduzy[i].direction == true ? 1 : -1;
            RotateMeduza(meduzy[i], rotationYSpeed * -value);
        }
    }

    void MeduzaMovement()
    {
        for (int i = 0; i < meduzy.Length; i++)
        {

            //jezeli meduza jest obok collidera
            if (meduzy[i].transform.localPosition.x > SwimmingArea.size.x / 2 || meduzy[i].transform.localPosition.x < -SwimmingArea.size.x / 2
                || meduzy[i].transform.localPosition.z > SwimmingArea.size.z / 2 || meduzy[i].transform.localPosition.z < -SwimmingArea.size.z / 2)
            {
                float value = meduzy[i].direction == true ? 1 : -1;
                RotateMeduza(meduzy[i], rotationYSpeed * 3 * value);
            }

            //jezeli meduza jest pod colliderem
            if (meduzy[i].transform.localPosition.y < -SwimmingArea.size.y / 2)
            {
                if (meduzy[i].wznoszenie == false)
                {
                    Debug.Log("POD");
                    meduzy[i].GetComponent<Animator>().SetTrigger("move");
                    meduzy[i].wznoszenie = true;
                }

            }
            //jezeli meduza jest nad colliderem
            else if (meduzy[i].transform.localPosition.y > SwimmingArea.size.y / 2)
            {

                if (meduzy[i].wznoszenie == true)
                {
                    Debug.Log("NAD");
                    meduzy[i].GetComponent<Animator>().SetTrigger("stop");
                    meduzy[i].wznoszenie = false;
                }

            }
            /* 
            Debug.Log(meduzy[0].wznoszenie);
            float dir = meduzy[i].wznoszenie == true ? 1 : -1;
            meduzy[i].transform.position += new Vector3(0, dir * (swimmingUPSpeed * meduzy[i].GetComponent<Animator>().speed), 0);
            */

            if (meduzy[i].wznoszenie)
            {
                meduzy[i].speed=0;
                AnimatorStateInfo animationState = meduzy[i].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
                AnimatorClipInfo[] myAnimatorClip = meduzy[i].GetComponent<Animator>().GetCurrentAnimatorClipInfo(0);
                float myTime = animationState.normalizedTime % 1;

                meduzy[i].transform.position += new Vector3(0, speedCurve.Evaluate(myTime) * swimmingUPSpeed * meduzy[i].GetComponent<Animator>().speed, 0);


            }
            else
            {
                meduzy[i].speed = -1 * Time.deltaTime;
            }

            meduzy[i].transform.position += new Vector3(0, meduzy[i].speed, 0);
            //meduzy[i].transform.position += Vector3.up * Time.deltaTime * swimmingSpeed;

            //meduzy[i].transform.position -= new Vector3(0, (Time.deltaTime * (maxSwimmingSpeed-meduzy[i].predkosc) *predkoscOpadania),0);

            meduzy[i].transform.localPosition += meduzy[i].transform.forward * Time.deltaTime * swimmingSpeed;
        }
    }
    #region rotate
    void RotateMeduza(Meduza obj, float value)
    {

        obj.transform.rotation *= Quaternion.Euler(0, value * Time.deltaTime, 0);
    }
    #endregion

}
