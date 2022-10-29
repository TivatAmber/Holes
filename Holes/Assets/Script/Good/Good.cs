using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Good : MonoBehaviour
{
    public Rigidbody goodBody;
    //正常
    public float livingTimeMax;
    public float dieTime;
    private float livingTime;
    //缩放
    public float scaleCD;
    private float scaleTime;
    //闪现
    public float flashCD;
    private float flashTime;

    private void Start()
    {
        scaleTime = scaleCD;
    }

    private void FixedUpdate()
    {
        livingTime += Time.fixedDeltaTime;
        if (livingTime > livingTimeMax - dieTime)
        {
            //play 枯萎动画
        }
        if (livingTime > livingTimeMax)
        {
            Destroy(gameObject);
        }
        if (scaleTime <= scaleCD)
        {
            scaleTime += Time.fixedDeltaTime;
        }
        if (flashTime <= flashCD)
        {
            flashTime += Time.fixedDeltaTime;
        }
    }
    public void BeingLarge(float scale)
    {
        if (scaleTime > scaleCD)
        {
            scaleTime = 0;
            transform.localScale *= scale;
            GetComponent<Rigidbody>().velocity /= scale;
            GetComponent<Rigidbody>().mass *= scale;
            if (transform.localScale.x > 4)
            {
                print("太大了！");
            }
        }
    }
    public void FlashTo(Transform target)
    {
        if (flashTime > flashCD)
        {
            flashTime = 0;
            GetComponent<Rigidbody>().MovePosition(target.position + target.forward);
            GetComponent<Rigidbody>().velocity = Vector3.Distance(Vector3.zero, GetComponent<Rigidbody>().velocity) * target.forward;
        }
    }

    
}
