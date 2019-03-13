using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestsScreenController : MonoBehaviour
{

    public Texture diamondTexture;
    public GameObject zadania;
    public Text opis;
    public GameObject diamondExample;
    public GameObject lockerExample;
    public List<GameObject> diamonds = new List<GameObject>();
    private int currentSelectedDiamond;

    public void ShowQuestsScreen()
    {
        zadania.SetActive(true);
        opis.gameObject.SetActive(true);
        GenerateDiamonds();
    }
    public void HideQuestsScreen()
    {
        zadania.SetActive(false);
        opis.gameObject.SetActive(false);
    }
    public void SelectQuest(int i, string description)
    {
        //Debug.Log("Select diamond number: " + i);
        if (i <= diamonds.Count && i > 0)
        {
            DeselectQuest(currentSelectedDiamond);
            diamonds[i - 1].GetComponent<Image>().color = Color.red;
            diamonds[i - 1].transform.localScale = new Vector3(1.6f, 1.6f, 1.6f);
            currentSelectedDiamond = i;

            opis.text = description;
        }

    }
    public void DeselectQuest(int i)
    {
        if (i <= diamonds.Count && i > 0)
        {
            diamonds[i - 1].GetComponent<Image>().color = Color.white;
            diamonds[i - 1].transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void GenerateDiamonds()
    {
        for (int i = 0; i < diamonds.Count; i++)
            Destroy(diamonds[i].gameObject);
        diamonds.Clear();

        for (int i = 0; i < GameManager.Instance.QuestsSystem.quests.Count; i++)
        {
            if (i < diamonds.Count && diamonds[i] != null) Destroy(diamonds[i].gameObject);

            GameObject newDiamond;
			Debug.Log(i+1);
            if (!GameManager.Instance.QuestsSystem.IsQuestLocked(i+1)) newDiamond = Instantiate(diamondExample, zadania.transform, true);
            else newDiamond = Instantiate(lockerExample, zadania.transform, true);
            diamonds.Add(newDiamond);
            newDiamond.SetActive(true);
        }
    }
}
