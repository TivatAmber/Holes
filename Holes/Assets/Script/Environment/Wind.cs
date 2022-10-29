using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public int level;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Good"))
        {
            if (level != 0)
            {
                other.GetComponent<Good>().goodBody.AddForce(transform.forward * level, ForceMode.Force);
            }
        }
    }
    
}
