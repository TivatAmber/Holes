using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameMenu : BaseUIEvent
{
    // �˵�
    private CanvasGroup gameMenu;
    private CanvasGroup gameSettingMenu;
    // ��ǰ�ؿ�
    private int nowLevel;
    private TextMeshProUGUI levelText;
    // ��ǰ����
    private TextMeshProUGUI scoreText;
    // ����ʱ��
    private TextMeshProUGUI resetTimeText;
    private void Start()
    {
        gameMenu = GetComponent<CanvasGroup>();
        gameSettingMenu = GameObject.Find("GameSettingMenu").GetComponent<CanvasGroup>();
        levelText = GameObject.Find("NowLevel").GetComponent<TextMeshProUGUI>();
        resetTimeText = GameObject.Find("ResetTime").GetComponent<TextMeshProUGUI>();
        scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();

        nowLevel = 0;
        UpdateLevel();
        UpdateScore(0);
        UpdateResetTime(0.0f);
    }
    public void ShowSetting()
    {
        Time.timeScale = 0;
        Show(gameSettingMenu);
        Hide(gameMenu);
    }
    #region �������
    public void UpdateLevel()
    {
        nowLevel++;
        levelText.text = "nowLevel: " + nowLevel.ToString();
    }
    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
    public void UpdateResetTime(float resetTime)
    {
        resetTimeText.text = resetTime.ToString("f2");
    }
    #endregion
}
