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
        public bool ukonczone = false;
        public QuestData(int qn, Quest q, GameObject qo)
        {
            questNumber = qn; quest = q; questObjects = qo;
        }
    }

    public void Init()
    {
        // if (PlayerPrefs.HasKey("Quest1"))
        //     PlayerPrefs.DeleteKey("Quest1");
        // if (PlayerPrefs.HasKey("Quest2"))
        //     PlayerPrefs.DeleteKey("Quest2");
        // if (PlayerPrefs.HasKey("Quest3"))
        //     PlayerPrefs.DeleteKey("Quest3");
        // if (PlayerPrefs.HasKey("Quest4"))
        //     PlayerPrefs.DeleteKey("Quest4");
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
            GameObject clone = Instantiate(quest.QuestObjects, currentQuestParent.transform, false);
            clone.SetActive(true);
            currentQuest = new QuestData(number, quest, clone);
            MenagerPolek mp = GetComponentInChildren<MenagerPolek>();
            if(mp != null) mp.Prepare();

            //Debug.Log(number);
            GameManager.Instance.GUIcontroller.questsScreen.SelectQuest(number);
        }
    }
    public bool IsQuestLocked(int number)
    {
        if (!PlayerPrefs.HasKey("Quest" + number)) return true;
        return false;
    }
    public void UnlockQuest(int number)
    {
        PlayerPrefs.SetInt("Quest" + number, 1);
    }
    public void CompleteQuest(int number)
    {
        PlayerPrefs.SetInt("Quest" + number, 2);
        UnlockQuest(number + 1);
        currentQuest.ukonczone = true;
    }
    public void CompleteCurrentQuest()
    {
        CompleteQuest(currentQuest.questNumber);
    }
    private bool axisInUse = false;
    public void InputListener()
    {
        if (GameManager.Instance.InputManager.GetKeyDown(InputManager.InputAction.menuPauza))
        {
            GameManager.Instance.GUIcontroller.questsScreen.HideQuestsScreen();
            GameManager.Instance.GUIcontroller.mainMenuController.ShowMainMenu(6);
        }
        // else if (GameManager.Instance.InputManager.GetKeyDown(InputManager.InputAction.menuZatwierdz))
        // {
        //     GameManager.Instance.PlayerStatesSystem.SetGameState("game");
        //     currentQuest.questObjects.GetComponent<QuestComponent>().lerpToPlayer.CameraLerpTo();
        //     GameManager.Instance.GUIcontroller.questsScreen.HideQuestsScreen();
        // }
        // else
        // {
        //     float value = Input.GetAxis("Horizontal");

        //     if (value < 0.03f && value > -0.03f) axisInUse = false;
        //     if (!axisInUse)
        //     {

        //         if (value > 0.03f)
        //         {
        //             axisInUse = true;
        //             int nextActiveQuest = NextActiveQuestNumber();
        //             if (nextActiveQuest > 0)
        //                 ShowQuest(nextActiveQuest);
        //         }
        //         else if (value < -0.03f)
        //         {
        //             axisInUse = true;
        //             int previousActiveQuest = PreviousActiveQuestNumber();
        //             if (previousActiveQuest > 0)
        //                 ShowQuest(previousActiveQuest);
        //         }
        //     }
        // }
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
