using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct KeyOrder
{
    public sbyte H;//ºáÖá
    public sbyte V;//×ÝÖá
    public sbyte C;//½»»¥
    public sbyte R;//ÉãÏñ»úÐý×ª
    public sbyte LShift;
}

public class InputManager : MonoSingleton<InputManager>
{
    public KeyOrder keyOrder;
    public float MouseX;
    public float MouseY;
    public bool Click;
    private float rotateTime;
    public float rotateCD;

    private Machine machine;
    public RaycastHit raycastHit;
    public LayerMask layerMask;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
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

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100, layerMask))
            {
                GameObject target = raycastHit.collider.gameObject;
                if (target.CompareTag("Machine"))
                {
                    if (target.GetComponent<Machine>() != null)
                    {
                        if (target.GetComponent<Machine>().controlable == true)
                        {
                            if (machine != null) machine.controling = false;
                            if (machine != null && machine.gameObject.GetComponent<Portal>() != null && target.GetComponent<Portal>() != null)
                            {
                                machine.gameObject.GetComponent<Portal>().BindingPortal(target);
                                machine = null;
                            }
                            else
                            {
                                machine = target.GetComponent<Machine>();
                                machine.controling = true;
                            }
                        }
                        else
                        {
                            target.GetComponent<Machine>().Turn();
                        }
                    }
                }
                else
                {
                    if (machine != null)
                    {
                        machine.controling = false;
                        machine = null;
                    }
                }
            }
        }
    }
    private void KeyCheck()
    {
        /*if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.lockState != CursorLockMode.None)
                Cursor.lockState = CursorLockMode.None;
            else Cursor.lockState = CursorLockMode.Locked;
        }*/




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
        if (rotateTime > rotateCD)
        {
            if (Input.GetKey(KeyCode.G))
            {
                keyOrder.R++;
                rotateTime = 0.0f;
            }
            if (Input.GetKey(KeyCode.H))
            {
                keyOrder.R--;
                rotateTime = 0.0f;
            }
        }
        else
        {
            rotateTime += Time.deltaTime;
        }
    } 

}
