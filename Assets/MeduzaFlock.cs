using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeduzaFlock : MonoBehaviour
{

    public float swimmingSpeed;
    public float rotationSpeed;
    public float rotationYSpeed;
    public float distanceToTurnBack = 1f;

    public float sizeMin;
    public float sizeMax;

    public int numberOfMeduza;
    public GameObject MeduzaPrefab;

    public float maxRotation;


    Meduza[] meduzy;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        SpawnMeduza();
    }

    void SpawnMeduza()
    {
        meduzy = new Meduza[numberOfMeduza];
        for (int i = 0; i < numberOfMeduza; i++)
        {
            GameObject Meduza = Instantiate(MeduzaPrefab, transform);
            SetRandomPosition(Meduza);
            SetRandomRotation(Meduza);
            SetRandomScale(Meduza);
            meduzy[i] = Meduza.GetComponent<Meduza>();
        }
    }
    void SetRandomPosition(GameObject go)
    {
        go.transform.localPosition = new Vector3(Random.Range(-distanceToTurnBack, distanceToTurnBack), Random.Range(-distanceToTurnBack, distanceToTurnBack), Random.Range(-distanceToTurnBack, distanceToTurnBack));
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
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        GoMeduzaUp();
        RotateMeduza();
    }

    void GoMeduzaUp()
    {
        for (int i = 0; i < meduzy.Length; i++)
        {
            meduzy[i].transform.position += meduzy[i].Mesh.transform.forward * Time.deltaTime * swimmingSpeed;
        }
    }
    void RotateMeduza()
    {

        for (int i = 0; i < meduzy.Length; i++)
        {
            meduzy[i].vector.transform.LookAt(transform.position);
            meduzy[i].Mesh.transform.rotation *= Quaternion.Euler(0, rotationYSpeed * Time.deltaTime, 0);
            if (Vector3.Distance(meduzy[i].transform.position, transform.position) > distanceToTurnBack)
            {
                //meduzy[i].vector.transform.LookAt(transform.position);
                //Quaternion pom = Quaternion.Euler(meduzy[i].vector.transform.position.x, meduzy[i].vector.transform.position.y , meduzy[i].vector.transform.position.z+ 90);
                meduzy[i].Mesh.transform.rotation = Quaternion.Lerp(meduzy[i].Mesh.transform.rotation, meduzy[i].vector.transform.rotation, rotationSpeed*Time.deltaTime);
            }
        }
    }
}
