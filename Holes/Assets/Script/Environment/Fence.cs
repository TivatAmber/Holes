using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MonoBehaviour
{
    public float limitSize;
    public Transform up;
    public Transform down;
    private void FixedUpdate()
    {
        
        up.position = new Vector3(up.position.x, limitSize / 2 + 0.3f, up.position.z);
        down.position = new Vector3(down.position.x, -limitSize / 2 - 0.3f, down.position.z);
    }
}
