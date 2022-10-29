using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBinding : Binding
{
    Canvas canvas;
    private void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = Camera.main;
    }
}
