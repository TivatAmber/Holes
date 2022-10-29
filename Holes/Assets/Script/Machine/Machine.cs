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
    #region �ƶ�
    [Header("Move")]
    public Rigidbody machineBody;

    public float speed;
    public float firction;
    public float rotateSpeed;
    #endregion

    #region �߼�
    [Header("State")]
    public bool controlable;//�Ƿ�ɱ��ٿ�
    public bool controling;//�Ƿ��ڱ��ٿ�
    public bool working;//�Ƿ�����
    //������ٿأ������ƶ���ת
    //��E�����л�����״̬
    protected virtual void FixedUpdateWithMachine()
    {
        //�����ƶ�
        if (controling)
        {
            machineBody.AddForce(speed * (1 + InputManager.Instance.keyOrder.LShift) * (InputManager.Instance.keyOrder.V * transform.forward + InputManager.Instance.keyOrder.H * transform.right) - new Vector3(machineBody.velocity.x, 0, machineBody.velocity.z) * firction, ForceMode.Force);
            gameObject.transform.Rotate(0, rotateSpeed * Input.GetAxis("Mouse X"), 0);
        }
        else
        {
            machineBody.velocity = Vector3.zero;
        }

        //�����ر�CD
        if (turnTime < turnCD)
        {
            turnTime += Time.fixedDeltaTime;
        }
    }
    #endregion

    #region ����
    [Header("CD")]
    public float turnCD;
    private float turnTime;
    
    //�����ر�
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
