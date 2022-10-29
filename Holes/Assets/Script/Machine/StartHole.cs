using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartHole : Machine
{
    public List<GameObject> goods;
    public float goodSpeed;
    public float summonCD;
    private float summonTime;

    public int numMax;
    private int num;
    private void Start()
    {
        controlable = false;
    }
    protected override void FixedUpdateWithMachine()
    {
        base.FixedUpdateWithMachine();

        if (working)
        {
            summonTime += Time.fixedDeltaTime;
            if (summonTime > summonCD)
            {
                Summon();
                summonTime = 0;
                num++;
            }
        }

        if (num >= numMax)
        {
            working = false;
            num = 0;
        }
    }
    private void Summon()
    {
        for(int i = 0; i < goods.Count; ++i)
        {
            GameObject good = Instantiate(goods[0]);
            good.transform.position = transform.position;
            good.GetComponent<Rigidbody>().AddForce(goodSpeed * transform.forward, ForceMode.Impulse);
        }

    }
}
