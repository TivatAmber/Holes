using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleHole : Machine
{
    public int level;
    public float levelUpCD;
    private float levelUpTime;
    public int Level
    {
        get => level;
        set
        {
            level = value;
            if (value <= 0)
            {
                
            }
            if (value > 0)
            {
                
            }
        }
    }

    private void Start()
    {
        controlable = true;
    }
    protected override void FixedUpdateWithMachine()
    {
        base.FixedUpdateWithMachine();
        //µ÷½Úµ²Î»
        if (levelUpTime < levelUpCD)
        {
            levelUpTime += Time.fixedDeltaTime;
        }
        if (controling && levelUpTime >= levelUpCD && InputManager.Instance.keyOrder.C == 1)
        {
            Level++;
            levelUpTime = 0;
            if (Level > 2) Level = -2;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Good"))
        {
            other.GetComponent<Good>().BeingLarge(Mathf.Pow(1.414f, Level));
        }
    }
}