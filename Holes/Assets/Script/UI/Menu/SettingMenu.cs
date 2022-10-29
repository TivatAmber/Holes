using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMenu : BaseUIEvent
{
    CanvasGroup mainMenu;
    CanvasGroup settingMenu;
    private void Start()
    {
        settingMenu = GetComponent<CanvasGroup>();
        mainMenu = GameObject.Find("MainMenu").GetComponent<CanvasGroup>();
    }
    public void BackMain()
    {
        Show(mainMenu);
        Hide(settingMenu);
    }
}
