using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    public string machineName;

    private void FixedUpdate()
    {
        FixedUpdateWithMachine();
    }
    #region 移动
    [Header("Move")]
    public Rigidbody machineBody;

    public float speed;
    public float firction;
    public float rotateSpeed;
    #endregion

    #region 逻辑
    [Header("State")]
    public bool controlable;//是否可被操控
    public bool controling;//是否在被操控
    public bool working;//是否工作中
    //如果被操控，可以移动旋转
    //按E可以切换工作状态
    protected virtual void FixedUpdateWithMachine()
    {
        //操作移动
        if (controling)
        {
            machineBody.AddForce(speed * (1 + InputManager.Instance.keyOrder.LShift) * (InputManager.Instance.keyOrder.V * transform.forward + InputManager.Instance.keyOrder.H * transform.right) - new Vector3(machineBody.velocity.x, 0, machineBody.velocity.z) * firction, ForceMode.Force);
            gameObject.transform.Rotate(0, rotateSpeed * Input.GetAxis("Mouse X"), 0);
        }
        else
        {
            machineBody.velocity = Vector3.zero;
        }

        //启动关闭CD
        if (turnTime < turnCD)
        {
            turnTime += Time.fixedDeltaTime;
        }
    }
    #endregion

    #region 交互
    [Header("CD")]
    public float turnCD;
    private float turnTime;
    
    //启动关闭
    public virtual void Turn()
    {
        if (turnTime >= turnCD)
        {
            turnTime = 0;
            working = !working;
        }

    }
    #endregion

}
