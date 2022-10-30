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
    /// <summary>
    /// 绑定传送门
    /// </summary>
    /// <param name="other">目标传送门</param>
    public void BindingPortal(GameObject other)
    {
        anotherPortal = other.GetComponent<Machine>();
    }
}
