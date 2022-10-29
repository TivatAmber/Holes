using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : Machine
{
    public float levelUpCD;
    private float levelUpTime;
    [Header("Wind")]
    public Wind wind;

    public int Level
    {
        get => wind.level;
        set
        {
            wind.level = value;
            if(value <= 0)
            {
                transform.GetComponentInChildren<ParticleSystem>().Stop();
            }
            if(value > 0)
            {
                transform.GetComponentInChildren<ParticleSystem>().Play();
            }
        }
    }
    protected override void FixedUpdateWithMachine()
    {
        base.FixedUpdateWithMachine();

        if (levelUpTime < levelUpCD)
        {
            levelUpTime += Time.fixedDeltaTime;
        }

        if(controling && levelUpTime >= levelUpCD && InputManager.Instance.keyOrder.C == 1)
        {
            Level += 2;
            levelUpTime = 0;
            if (Level > 10) Level = -10;
        }
    }
}
