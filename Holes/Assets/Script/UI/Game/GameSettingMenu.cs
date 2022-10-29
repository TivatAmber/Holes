using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSettingMenu : BaseUIEvent
{
    CanvasGroup gameSettingMenu;
    CanvasGroup gameMenu;
    private void Start()
    {
        gameSettingMenu = GetComponent<CanvasGroup>();
        gameMenu = GameObject.Find("GameMenu").GetComponent<CanvasGroup>();
    }

    public void BackGame()
    {
        Time.timeScale = 1;
        Show(gameMenu);
        Hide(gameSettingMenu);
    }
    public void BackMenu()
    {
        ChangeScene("Menu");
    }
}
