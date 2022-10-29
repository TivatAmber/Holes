using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndHole : Machine
{
    private int score;
    public int scoreMax;

    public float resetCD;
    private float resetTime;
    
    public Transform target;
    private GameMenu gameMenu; // 绑定游戏界面
    private void Start()
    {
        resetTime = resetCD;
        gameMenu = GameObject.Find("GameMenu").GetComponent<GameMenu>();
    }
    protected override void FixedUpdateWithMachine()
    {
        base.FixedUpdateWithMachine();
        if (resetTime < resetCD)
        {
            resetTime += Time.fixedDeltaTime;
            gameMenu.UpdateResetTime((resetCD - resetTime));
        }
        if (resetTime > resetCD)
        {
            score = 0;
            gameMenu.UpdateResetTime(0.0f);
            gameMenu.UpdateScore(score);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Good"))
        {
            resetTime = 0;
            Destroy(other.gameObject);
            if (score >= scoreMax - 1) // 如果不-1那么即使收集到 scoreMax 也不会跳关
            {
                GameObject.Find("Robot").transform.position = target.position;//到下一关
                gameMenu.UpdateLevel();
                score = -1;
            }
            else if (score != -1)
            {
                score++;
                gameMenu.UpdateScore(score);
            }
        }
    }
}
