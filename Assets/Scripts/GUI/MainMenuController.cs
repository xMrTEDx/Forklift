using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{

    public MainMenuWindow mainWindow;
    public MainMenuWindow creditsWindow;
	public MainMenuWindow[] windows;
    private MainMenuWindow currentWindow;

    CanvasGroup canvasGroup;

    public MainMenuWindow CurrentWindow
    {get;    set;}

    public void Init()
    {
        GetComponents();
		windows = GetComponentsInChildren<MainMenuWindow>(true);
		foreach (var item in windows) item.Init(this);

        ShowMainMenu(6);
    }

    public void GetComponents()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void ShowMainMenu(float speed)
    {
        gameObject.SetActive(true);
		canvasGroup.interactable = true;
        StartCoroutine(ShowMainMenuCoroutine(speed));
		mainWindow.EnableWindow();
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
        StartCoroutine(HideMainMenuCoroutine(speed));
    }
    IEnumerator HideMainMenuCoroutine(float speed)
    {
        canvasGroup.alpha = 1;
        while (canvasGroup.alpha > 0)
        {
            yield return null;
            canvasGroup.alpha -= Time.deltaTime * speed;
        }
        if(currentWindow) currentWindow.DisableWindow();
        gameObject.SetActive(false);
    }
}
