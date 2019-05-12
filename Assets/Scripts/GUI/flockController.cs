using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flockController : MonoBehaviour {

	public float swimmingSpeed;
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

	public SwimmingOrientation swimmingOrientation;

	public enum SwimmingOrientation
	{
		up,
		forward
	}

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
        meduzy = new Meduza[numberOfMeduza];
        for (int i = 0; i < numberOfMeduza; i++)
        {
            meduzy[i] = Instantiate(MeduzaPrefab, SwimmingArea.transform).GetComponent<Meduza>();
            SetRandomPosition(meduzy[i].gameObject);
            SetRandomRotation(meduzy[i].gameObject);
            SetRandomScale(meduzy[i].gameObject);
			SetRandomAnimationSpeed(meduzy[i].GetComponent<Animator>());
        }
    }
    void SetRandomPosition(GameObject go)
    {
        go.transform.localPosition = new Vector3(Random.Range(-SwimmingArea.size.x/2, SwimmingArea.size.x/2), Random.Range(-SwimmingArea.size.y/2, SwimmingArea.size.y/2), Random.Range(-SwimmingArea.size.z/2, SwimmingArea.size.z/2));
    }
    void SetRandomRotation(GameObject go)
    {
        go.transform.localRotation = Quaternion.Euler(Random.Range(-maxRotation, maxRotation), Random.Range(-maxRotation, maxRotation), Random.Range(-maxRotation, maxRotation));
    }
    void SetRandomScale(GameObject go)
    {
        float scale = Random.Range(sizeMin, sizeMax);
        go.transform.localScale = new Vector3(scale, scale, scale);
    }
	void SetRandomAnimationSpeed(Animator animator)
	{
		animator.speed = Random.Range(0.9f,1.1f);
	}
    #endregion
    
    void Update()
    {
        MeduzaMovement();
        //RotateMeduza();
    }

    void MeduzaMovement()
    {
        for (int i = 0; i < meduzy.Length; i++)
        {
            
            //jezeli meduza jest obok collidera
            if(meduzy[i].transform.localPosition.x > SwimmingArea.size.x/2 || meduzy[i].transform.localPosition.x < -SwimmingArea.size.x/2
                || meduzy[i].transform.localPosition.z > SwimmingArea.size.z/2 || meduzy[i].transform.localPosition.z < -SwimmingArea.size.z/2)
            {

            }

            //jezeli meduza jest pod colliderem
            if(meduzy[i].transform.localPosition.y < -SwimmingArea.size.y/2)
            {
                Debug.Log("POD");
            }
            //jezeli meduza jest nad colliderem
            else if(meduzy[i].transform.localPosition.y > SwimmingArea.size.y/2)
            {
                Debug.Log("NAD");
            }



			AnimatorStateInfo animationState = meduzy[i].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
			AnimatorClipInfo[] myAnimatorClip = meduzy[i].GetComponent<Animator>().GetCurrentAnimatorClipInfo(0);
            float myTime = animationState.normalizedTime%1;
			Debug.Log(myTime);
			Vector3 orientation = swimmingOrientation == SwimmingOrientation.up ? meduzy[i].transform.up : meduzy[i].transform.forward;
            meduzy[i].predkosc /=1.05f;
            if(meduzy[i].predkosc<maxSwimmingSpeed)
            meduzy[i].predkosc += speedCurve.Evaluate(myTime) *swimmingSpeed*meduzy[i].GetComponent<Animator>().speed;

            meduzy[i].transform.position += orientation * Time.deltaTime * meduzy[i].predkosc;

            //meduzy[i].transform.position -= new Vector3(0, (Time.deltaTime * (maxSwimmingSpeed-meduzy[i].predkosc) *predkoscOpadania),0);
        }
    }
    #region rotate
    void RotateMeduza()
    {

        for (int i = 0; i < meduzy.Length; i++)
        {
            meduzy[i].transform.LookAt(transform.position);
            meduzy[i].transform.rotation *= Quaternion.Euler(0, rotationYSpeed * Time.deltaTime, 0);
            if (Vector3.Distance(meduzy[i].transform.position, transform.position) > distanceToTurnBack)
            {
                //meduzy[i].vector.transform.LookAt(transform.position);
                //Quaternion pom = Quaternion.Euler(meduzy[i].vector.transform.position.x, meduzy[i].vector.transform.position.y , meduzy[i].vector.transform.position.z+ 90);
                //meduzy[i].transform.rotation = Quaternion.Lerp(meduzy[i].transform.rotation, meduzy[i].vector.transform.rotation, rotationSpeed*Time.deltaTime);
            }
        }
    }
    #endregion

}
