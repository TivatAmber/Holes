using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct KeyOrder
{
    public sbyte H;//∫·÷·
    public sbyte V;//◊›÷·
    public sbyte C;//Ωªª•
    public sbyte LShift;
}

public class InputManager : MonoSingleton<InputManager>
{
    public KeyOrder keyOrder;
    public float MouseX;
    public float MouseY;
    public bool Click;

    public Machine machine;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    private void FixedUpdate()
    {
        KeyCheck();
        MouseCheck();
    }
    private void MouseCheck()
    {
        MouseX = Input.GetAxis("Mouse X");
        MouseY = Input.GetAxis("Mouse Y");
    }


    private void KeyCheck()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.lockState != CursorLockMode.None)
                Cursor.lockState = CursorLockMode.None;
            else Cursor.lockState = CursorLockMode.Locked;
        }




        keyOrder.H = 0;
        keyOrder.V = 0;
        keyOrder.C = 0;
        keyOrder.LShift = 0;
        if (Input.GetKey(KeyCode.A))
        {
            keyOrder.H = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            keyOrder.H = 1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            keyOrder.V = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            keyOrder.V = -1;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            keyOrder.C = -1;
        }
        if (Input.GetKey(KeyCode.E))
        {
            keyOrder.C = 1;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            keyOrder.C = 2;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            keyOrder.LShift = 1;
        }
    } 

}
