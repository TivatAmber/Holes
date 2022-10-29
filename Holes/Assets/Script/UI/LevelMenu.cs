using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenu : BaseUIEvent
{
    CanvasGroup mainMenu;
    CanvasGroup levelMenu;
    Transform levelList;
    public GameObject button;
    private void Start()
    {
        mainMenu = GameObject.Find("MainMenu").GetComponent<CanvasGroup>();
        levelMenu = GetComponent<CanvasGroup>();
        levelList = GameObject.Find("LevelList").GetComponent<Transform>();

        for (int i = 1; i <= 3; i++)
        {
            GameObject nowButton = Instantiate(button, levelList);
            nowButton.transform.localPosition = new Vector3(200 * i, -100, 0);
            GameObject nowText = nowButton.transform.GetChild(0).gameObject;
            Debug.Log(nowText);
            nowText.GetComponent<TMPro.TextMeshProUGUI>().text = "Level " + i.ToString();
        }
    }
    public void BackMain()
    {
        Show(mainMenu);
        Hide(levelMenu);
    }
}
