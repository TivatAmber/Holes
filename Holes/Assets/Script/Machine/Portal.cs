using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : Machine
{
    public Machine anotherPortal;
    public RaycastHit raycastHit;
    public LayerMask layerMask;
    protected override void FixedUpdateWithMachine()
    {
        if (controling)
        {
            gameObject.transform.Rotate(0, rotateSpeed * Input.GetAxis("Mouse X"), 0);
            //°ó¶¨´«ËÍÃÅ
            Cursor.lockState = CursorLockMode.None;
            if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out raycastHit, 100, layerMask))
                {
                    if (raycastHit.collider.gameObject.GetComponent<Portal>() != null)
                    {
                        anotherPortal = raycastHit.collider.gameObject.GetComponent<Portal>();
                        
                    }
                }
            }
            

        }
        else
        {
            machineBody.velocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (anotherPortal != null && other.CompareTag("Good"))
        {
            other.GetComponent<Good>().FlashTo(anotherPortal.transform);
        }
    }
}
