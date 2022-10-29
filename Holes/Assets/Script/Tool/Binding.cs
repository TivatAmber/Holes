using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Binding : MonoBehaviour
{
    private CameraManager cameraManager;
    private void Start()
    {
        Init();
    }
    protected void Init()
    {
        cameraManager = GameObject.Find("CameraManager").GetComponent<CameraManager>();
        cameraManager.target = transform;
    }
}
