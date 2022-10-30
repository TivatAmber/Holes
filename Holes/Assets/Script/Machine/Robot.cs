using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : Machine
{
    Machine machineC;
    private void Update()
    {
        if(machineC != null)
        {
            transform.SetPositionAndRotation(machineC.transform.position, machineC.transform.rotation);
            if(InputManager.Instance.keyOrder.C == -1 && machineC != null)
            {
                OutMachine(); 
            }
        }
    }
    private void InMachine(Transform target)
    {
        transform.SetPositionAndRotation(target.position, target.rotation);
        
        transform.GetComponent<MeshRenderer>().enabled = false;
        transform.GetComponent<BoxCollider>().enabled = false;

        machineC = target.GetComponent<Machine>();

        machineC.controling = true;
        machineC.GetComponent<BoxCollider>().isTrigger = false;
        controling = false;
        
    }
    public void OutMachine()
    {
        Cursor.lockState = CursorLockMode.Locked;

        transform.GetComponent<MeshRenderer>().enabled = true;
        transform.GetComponent<BoxCollider>().enabled = true;

        controling = true;
        machineC.controling = false;
        machineC.GetComponent<BoxCollider>().isTrigger = true;

        machineC = null;
    }
    

    private void OnTriggerStay(Collider other)
    {
        //要么操控要么打开
        if (machineC == null && InputManager.Instance.keyOrder.C == 1 && other.CompareTag("Machine"))
        {
            if (other.GetComponent<Machine>().controlable == true)
            {
                InMachine(other.transform);
            }

            else
            {
                other.GetComponent<Machine>().Turn();
            }
        }
    }
}
