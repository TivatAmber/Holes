using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoSingleton<CameraManager>
{
    public Transform target;
    public float speed;
    public float rotateSpeed;
    public float scale;
    public float scaleMax;
    public float scaleMin;
    private void Update()
    {
        
        Vector3 velocity = Vector3.zero;
        //transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, speed * Time.deltaTime);
        transform.position = target.position;
        if(Input.mouseScrollDelta.y != 0){
            scale += Input.mouseScrollDelta.y / 10;
            if (scale > scaleMax)
            {
                scale = scaleMax;
            }
            if (scale < scaleMin)
            {
                scale = scaleMin;
            }
            
            
        }
        transform.localScale = new Vector3(scale, scale, scale);
        if (InputManager.Instance.Click)
        {
            //transform.rotation
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, rotateSpeed * Time.deltaTime);
        }

    }



}
