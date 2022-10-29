using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float openTime;
    public float closeTime;
    private float ocTime;
    private void FixedUpdate()
    {
        if (ocTime < openTime + closeTime)
        {
            ocTime += Time.fixedDeltaTime;
        }
        else 
        {
            ocTime = 0;
            GetComponent<BoxCollider>().isTrigger = true;
        }
        if (ocTime >= openTime)//¹Ø±Õ
        {
            GetComponent<BoxCollider>().isTrigger = false;
        }
        
    }
}
