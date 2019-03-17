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
        if (!PlayerPrefs.HasKey("Quest1"))
            PlayerPrefs.SetInt("Quest1", 1);
    }

    public void ShowQuestsView()
    {
        GameManager.Instance.GUIcontroller.questsScreen.ShowQuestsScreen();
        GameManager.Instance.PlayerStatesSystem.SetGameState("quests");
        GameManager.Instance.PlayerStatesSystem.SetPlayerState("none");

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
            //Debug.Log("number: " + number);
            quest.lerpToQuestCamera.CameraLerpTo();

            if (currentQuest != null && currentQuest.questObjects != null) Destroy(currentQuest.questObjects);
            GameObject clone = Instantiate(quest.QuestObjects, currentQuestParent.transform, true);
            clone.SetActive(true);
            currentQuest = new QuestData(number, quest, clone);

            //Debug.Log(number);
            GameManager.Instance.GUIcontroller.questsScreen.SelectQuest(number);
        }
    }

    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         if (currentQuest.questNumber == 1) ShowQuest(2);
    //         else if (currentQuest.questNumber == 2) ShowQuest(3);
    //         else if (currentQuest.questNumber == 3) ShowQuest(4);
    //         else if (currentQuest.questNumber == 4) ShowQuest(1);
    //     }
    //     if (Input.GetKeyDown(KeyCode.O))
    //         currentQuest.questObjects.GetComponent<QuestComponent>().lerpToPlayer.CameraLerpTo();

    //     if (Input.GetKeyDown(KeyCode.Escape))
    //         {
    //             GameManager.Instance.GUIcontroller.mainMenuController.ShowMainMenu(1);
    //             GameManager.Instance.GUIcontroller.questsScreen.HideQuestsScreen();
    //         }
    // }
    public bool IsQuestLocked(int number)
    {
        if (!PlayerPrefs.HasKey("Quest" + number)) return true;
        return false;
    }
    private bool axisInUse = false;
    public void InputListener()
    {
        float value = Input.GetAxis("Horizontal");

        if (value < 0.03f && value > -0.03f) axisInUse = false;
        if (!axisInUse)
        {

            if (value > 0.03f)
            {
                axisInUse = true;
                int nextActiveQuest = NextActiveQuestNumber();
                if (nextActiveQuest > 0)
                    ShowQuest(nextActiveQuest);
            }
            else if (value < -0.03f)
            {
                axisInUse = true;
                int previousActiveQuest = PreviousActiveQuestNumber();
                if (previousActiveQuest > 0)
                    ShowQuest(previousActiveQuest);
            }
        }

        if(GameManager.Instance.InputManager.GetKeyDown(InputManager.InputAction.menuPauza))
            {
                GameManager.Instance.GUIcontroller.questsScreen.HideQuestsScreen();
                GameManager.Instance.GUIcontroller.mainMenuController.ShowMainMenu(6);
            }
    }
    private int NextActiveQuestNumber()
    {
        int number;
        for (int i = 1; i <= quests.Count; i++)
        {
            number = (currentQuest.questNumber - 1 + i) % quests.Count;
            if (!IsQuestLocked(number + 1)) return number + 1;
        }
        return -1;
    }
    private int PreviousActiveQuestNumber()
    {
        int number;
        for (int i = 1; i <= quests.Count; i++)
        {
            number = (currentQuest.questNumber - 1 - i);
            if (number < 0) number += quests.Count;
            if (!IsQuestLocked(number + 1)) return number + 1;
        }
        return -1;
    }
}
