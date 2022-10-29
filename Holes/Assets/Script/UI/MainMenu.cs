using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : BaseUIEvent
{
    CanvasGroup levelMenu;
    CanvasGroup mainMenu;
    private void Start()
    {
        levelMenu = GameObject.Find("LevelMenu").GetComponent<CanvasGroup>();
        mainMenu = GetComponent<CanvasGroup>();
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void ShowLevel()
    {
        Show(levelMenu);
        Hide(mainMenu);
    }
}
