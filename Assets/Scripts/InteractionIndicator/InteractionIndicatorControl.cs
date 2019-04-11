using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using States = StatesSystem.States;

[RequireComponent(typeof(InteractionIndicatorComponent))]
public class InteractionIndicatorControl : MonoBehaviour
{
    public static InteractionIndicatorControl currentHighlightedII = null;

    [Header("Player states which indicator is visible")]
    [Space]
    public States[] playerStates;
    [Header("Set true if II not require players in that state")]
    public bool onTriggerStayNotRequired;
    public bool disableAfterInteraction = true;
    [Header("In which quests visible")]
    
    [Space]
    [Header("Events")]

    [SerializeField]
    public UnityEvent e_Interaction = new UnityEngine.Events.UnityEvent();
    [Space]
    public InteractionIndicatorEvents interactionIndicatorEvents;

    [System.Serializable]
    public class InteractionIndicatorEvents
    {
        [SerializeField]
        public UnityEvent e_OnAreaEnter = new UnityEngine.Events.UnityEvent();
        [SerializeField]
        public UnityEvent e_OnAreaExit = new UnityEngine.Events.UnityEvent();
        [SerializeField]
        public UnityEvent e_OnInteractionAreaEnter = new UnityEngine.Events.UnityEvent();
        [SerializeField]
        public UnityEvent e_OnInteractionAreaExit = new UnityEngine.Events.UnityEvent();
    }

    InteractionIndicatorComponent interactionComponent;

    void Awake()
    {
        interactionComponent = gameObject.GetComponent<InteractionIndicatorComponent>();
        if (onTriggerStayNotRequired)
            OnAreaEnter();
    }
    void Update()
    {
        if (onTriggerStayNotRequired)
        {
            LookAtPlayer();
            CheckIfPlayerLookAt();
        }
    }
    public void LookAtPlayer()
    {
        if (Camera.main)
        {
            if (interactionComponent.iiPoint)
                interactionComponent.iiPoint.transform.LookAt(Camera.main.transform);
            if (interactionComponent.iiPointE)
                interactionComponent.iiPointE.transform.LookAt(Camera.main.transform);
        }
    }

    public void OnAreaEnter()
    {
        Debug.Log("Area");
        interactionComponent.iiPoint.SetActive(true);
        interactionComponent.iiPointE.SetActive(true);
        interactionComponent.iiPoint_SR.enabled = true;
        interactionIndicatorEvents.e_OnAreaEnter.Invoke();
    }
    public void OnAreaExit()
    {
        interactionComponent.iiPoint.SetActive(false);
        interactionComponent.iiPointE.SetActive(false);
        interactionComponent.iiPoint_SR.enabled = false;
        interactionIndicatorEvents.e_OnAreaExit.Invoke();
    }
    //////////////////////////////////////////////////////////
    public void OnInteractionAreaEnter()
    {
        Debug.Log("Interaction Area");
        interactionIndicatorEvents.e_OnInteractionAreaEnter.Invoke();
    }
    public void OnInteractionAreaExit()
    {
        interactionIndicatorEvents.e_OnInteractionAreaExit.Invoke();
        HideInteractionKey();
    }
    ////////////////////////////////////////////////////////////
    public void OnInteraction()
    {
        e_Interaction.Invoke();
        currentHighlightedII = null;

        if (disableAfterInteraction)
            InteractionDisable();
    }
    public void CheckIfPlayerLookAt()
    {
        if (Camera.main)
        {

            Vector3 interactionPointPosition = interactionComponent.iiPoint.transform.position;
            Vector3 dirFromMeToObject = (interactionPointPosition - Camera.main.transform.position).normalized;
            Vector3 myCurrentFacingDir = Camera.main.transform.forward;

            if (Vector3.Dot(dirFromMeToObject, myCurrentFacingDir) > 0.95)
            {
                if (currentHighlightedII == null)
                {
                    ShowInteractionKey();
                    currentHighlightedII = this;
                }

                if (currentHighlightedII == this)
                    if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton0))
                        OnInteraction();
            }
            else
            {
                if (currentHighlightedII == this)
                {
                    currentHighlightedII = null;
                    HideInteractionKey();
                }
            }

        }

    }
    private void InteractionDisable()
    {
        if (currentHighlightedII == this)
            currentHighlightedII = null;

        interactionComponent.iiPoint.SetActive(false);
        interactionComponent.iiPointE.SetActive(false);
        interactionComponent.iiPoint_SR.enabled = false;
        interactionComponent.iiPointE_SR.enabled = false;
    }
    private void ShowInteractionKey()
    {
        interactionComponent.iiPointE_SR.enabled = true;
        interactionComponent.iiPoint_SR.enabled = false;
    }

    private void HideInteractionKey()
    {
        interactionComponent.iiPointE_SR.enabled = false;
        interactionComponent.iiPoint_SR.enabled = true;

    }


}
