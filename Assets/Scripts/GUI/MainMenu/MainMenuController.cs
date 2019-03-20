using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainMenuController : MonoBehaviour
{

    public MainMenuWindow mainWindow;
    public MainMenuWindow creditsWindow;
    public MainMenuWindow[] windows;
    public GameObject WindowsRef;
    public LerpController mainLerpPoint;
    public MainMenuWindow CurrentWindow;
    public LerpController CurrentLerpPoint;

    CanvasGroup canvasGroup;

    Coroutine showhidecoroutine;

    public void Init()
    {
        GetComponents();
        windows = GetComponentsInChildren<MainMenuWindow>(true);
        foreach (var item in windows) item.Init(this);

        //ShowMainMenu(6);
    }

    public void GetComponents()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void ShowMainMenu(float speed)
    {
        GameManager.Instance.PlayerStatesSystem.SetGameState("mainmenu");
        GameManager.Instance.PlayerStatesSystem.SetPlayerState("none");

        UnityEvent afterLerpEvent = new UnityEvent();
        afterLerpEvent.AddListener(() =>
        {
            WindowsRef.SetActive(true);
            canvasGroup.interactable = true;
            if (showhidecoroutine != null) StopCoroutine(showhidecoroutine);
            showhidecoroutine = StartCoroutine(ShowMainMenuCoroutine(speed));
            mainWindow.EnableWindow();
        });

        mainLerpPoint.CameraLerpTo(afterLerpEvent);

        Cursor.visible = true;
    }
    IEnumerator ShowMainMenuCoroutine(float speed)
    {
        canvasGroup.alpha = 0;
        while (canvasGroup.alpha < 1)
        {
            yield return null;
            canvasGroup.alpha += Time.deltaTime * speed;
        }
    }
    public void HideMainMenu(float speed)
    {
        canvasGroup.interactable = false;
        if (showhidecoroutine != null) StopCoroutine(showhidecoroutine);
        showhidecoroutine = StartCoroutine(HideMainMenuCoroutine(speed));

        Cursor.visible = false;
    }
    IEnumerator HideMainMenuCoroutine(float speed)
    {
        canvasGroup.alpha = 1;
        while (canvasGroup.alpha > 0)
        {
            yield return null;
            canvasGroup.alpha -= Time.deltaTime * speed;
        }
        if (CurrentWindow) CurrentWindow.DisableWindow();
        CurrentWindow = null;
        CurrentLerpPoint = null;

        WindowsRef.SetActive(false);
    }
}
