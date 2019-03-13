using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuestsSystem : MonoBehaviour
{
    public GameObject currentQuestParent;
    public List<Quest> quests;
    [Header("Debug")]
    public QuestData currentQuest;
    [System.Serializable]
    public class QuestData
    {
        public int questNumber;
        public Quest quest;
        public GameObject questObjects;
        public QuestData(int qn, Quest q, GameObject qo)
        {
            questNumber = qn; quest = q; questObjects = qo;
        }
    }

    public void Init()
    {
        foreach (var item in quests)
        {
            item.Init(this);
        }
    }

    public void ShowQuestsView()
    {
        GameManager.Instance.GUIcontroller.questsScreen.ShowQuestsScreen();

        if (currentQuest != null && currentQuest.questNumber > 0)
            ShowQuest(currentQuest.questNumber);
        else
            ShowQuest(1);
    }
    public void ShowQuest(int number)
    {
        if (number <= quests.Count)
        {
            Quest quest = quests[number - 1];
            Debug.Log("number: " + number);

            quest.lerpToQuestCamera.CameraLerpTo();
            if (currentQuest != null && currentQuest.questObjects != null) Destroy(currentQuest.questObjects);
            GameObject clone = Instantiate(quest.QuestObjects, currentQuestParent.transform, true);
            clone.SetActive(true);
            currentQuest = new QuestData(number, quest, clone);

            Debug.Log(number);
            GameManager.Instance.GUIcontroller.questsScreen.SelectQuest(number,quests[number -1].description);
        }
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentQuest.questNumber == 1) ShowQuest(2);
            else if (currentQuest.questNumber == 2) ShowQuest(3);
            else if (currentQuest.questNumber == 3) ShowQuest(1);
        }
        if (Input.GetKeyDown(KeyCode.Return))
            currentQuest.questObjects.GetComponent<QuestComponent>().lerpToPlayer.CameraLerpTo();

        if (Input.GetKeyDown(KeyCode.Escape))
            {
                GameManager.Instance.GUIcontroller.mainMenuController.ShowMainMenu(1);
                GameManager.Instance.GUIcontroller.questsScreen.HideQuestsScreen();
            }
    }
    public bool IsQuestUnlocked(int number)
    {
        //TODO
        return true;
    }
}
