using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenu : BaseUIEvent
{
    CanvasGroup mainMenu;
    CanvasGroup levelMenu;
    public GameObject button;
    private void Start()
    {
        mainMenu = GameObject.Find("MainMenu").GetComponent<CanvasGroup>();
        levelMenu = GetComponent<CanvasGroup>();
    }
    public void BackMain()
    {
        Show(mainMenu);
        Hide(levelMenu);
    }
    public void ToChapter(string Chapter)
    {
        ChangeScene(Chapter);
    }
}
