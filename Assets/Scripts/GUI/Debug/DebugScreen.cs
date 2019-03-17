using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugScreen : MonoBehaviour
{

    public ZadaniaDebug odblokowanie;
    public ZadaniaDebug zablokowanie;
    public GameObject simpleButton;
    public GameObject screen;
    List<GameObject> ListaOdblokowanie = new List<GameObject>();
    List<GameObject> ListaZablokowanie = new List<GameObject>();

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        for (int i = 0; i < GameManager.Instance.QuestsSystem.quests.Count; i++)
        {
            GameObject buttonOdblokowanie = Instantiate(simpleButton, Vector3.zero, Quaternion.identity, odblokowanie.parent.transform);
            buttonOdblokowanie.GetComponentInChildren<Text>().text = "zadanie " + (i + 1);

            ListaOdblokowanie.Add(buttonOdblokowanie);

            buttonOdblokowanie.GetComponent<Button>().onClick.AddListener(() =>
            {
                string questnumber = "Quest" + (ListaOdblokowanie.IndexOf(buttonOdblokowanie) + 1);
                if (!PlayerPrefs.HasKey(questnumber))
                    PlayerPrefs.SetInt(questnumber, 1);
                Debug.Log("Odblokowano zadanie nr: " + questnumber);
            });
            buttonOdblokowanie.SetActive(true);

            GameObject buttonZablokowanie = Instantiate(simpleButton, Vector3.zero, Quaternion.identity, zablokowanie.parent.transform);
            buttonZablokowanie.GetComponentInChildren<Text>().text = "zadanie " + (i + 1);

            ListaZablokowanie.Add(buttonZablokowanie);

            buttonZablokowanie.GetComponent<Button>().onClick.AddListener(() =>
            {
                string questnumber = "Quest" + (ListaZablokowanie.IndexOf(buttonZablokowanie) + 1);
                if (PlayerPrefs.HasKey(questnumber))
                    PlayerPrefs.DeleteKey(questnumber);
                Debug.Log("Zablokowano zadanie nr: " + questnumber);
            });
            buttonZablokowanie.SetActive(true);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            screen.SetActive(!screen.activeSelf);
        }

    }
}
