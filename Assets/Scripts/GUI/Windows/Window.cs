using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class Window : MonoBehaviour
{
    CanvasGroup canvasGroup;
    public UnityEvent e_onEnable;
    public UnityEvent e_onDisable;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public virtual void EnableWindow()
    {
        gameObject.SetActive(true);
        e_onEnable.Invoke();
        StartCoroutine(SelectFirstButton());
    }
    public virtual void DisableWindow()
    {
        gameObject.SetActive(false);
        e_onDisable.Invoke();
    }
    public void InteractableOff()
    {
        canvasGroup.interactable = false;
    }
    public void InteractableOn()
    {
        canvasGroup.interactable = true;
    }
    IEnumerator SelectFirstButton()
    {
        yield return null;
        if (EventSystem.current.currentSelectedGameObject != null) EventSystem.current.SetSelectedGameObject(null);
        Button firstButton = GetComponentInChildren<Button>(false);
        if (firstButton) firstButton.Select();
    }
}
