using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : BaseUIEvent
{
    CanvasGroup levelMenu;
    CanvasGroup settingMenu;
    CanvasGroup mainMenu;
    private void Start()
    {
        mainMenu = GetComponent<CanvasGroup>();
        levelMenu = GameObject.Find("LevelMenu").GetComponent<CanvasGroup>();
        settingMenu = GameObject.Find("SettingMenu").GetComponent<CanvasGroup>();
    }
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
#region ¿ªÆô½çÃæ
    public void ShowLevel()
    {
        Show(levelMenu);
        Hide(mainMenu);
    }
    public void ShowSetting()
    {
        Show(settingMenu);
        Hide(mainMenu);
    }
#endregion
}
