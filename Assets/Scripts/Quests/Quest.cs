using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Quest : MonoBehaviour
{
    public GameObject currentObject;
    private QuestsSystem questsSystem;
    public LerpController lerpToQuestCamera;
    public GameObject QuestObjects;

    public ForkliftController forkliftController;

    [Header("Events")]
    public UnityEvent toPrepare;

    [TextArea]
    public string description;
    public Goal[] cele;
    public class Goal
    {
        public StatusZadania status;
        public string opis;

        public enum StatusZadania
        {
            oczekujace,
            wykonane,
            niewykonane,
        }
    }
    public void Init(QuestsSystem qs)
    {
        questsSystem = qs;
    }

    public void PrepareQuest()
    {
        toPrepare.Invoke();
    }
}
