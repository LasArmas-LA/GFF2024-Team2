using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerBase : MonoBehaviour
{
    public enum playerMode
    {
        Idle,
        MovetoTarget,
        MovetoBoss,
        Attack,
        Max,
    }
    public playerMode mode = playerMode.Idle;



    [SerializeField]
    public GameObject cursorPoint = null;

    [SerializeField]
    public GameObject boss = null;


    [SerializeField]
    [Header("��]���x")]
    public float rotationValue = 0;

    [SerializeField]
    [Header("�ړ����x")]
    public float moveValue = 0;

    [SerializeField]
    [Header("�I���������ƒ�~�ʒu�Ƃ̋���")]
    public float positionRange = 0;

    [SerializeField]
    [Header("�˒�����")]
    public float attackRange = 0;

    [SerializeField]
    [Header("���̑���")]
    public float lineWidth = 0;

    [SerializeField]
    public Material lineMaterial = null;


    private GameObject mpobj = null;
    public bool canAttackFlag = false;
    public bool targetFlag = false;

    [SerializeField]
    public LineRenderer lineRenderer = null;

    private void Awake()
    {
        mpobj = cursorPoint.transform.GetChild(0).gameObject; 
        mpobj.SetActive(false);

        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.material = lineMaterial;
    }





    public void Idle()
    {
        lineRenderer.enabled = false;
        TargetRot(boss);
    }


    public void MovetoTarget()
    {
        if (lineRenderer.enabled == false) { lineRenderer.enabled = true; }

        //Line�̈ʒu�����
        Vector3 startPos = this.transform.position;
        startPos.y = 0.1f;
        Vector3 endPos = cursorPoint.transform.position;
        endPos.y = 0.1f;
        var positions = new Vector3[]
        {
            startPos,
            endPos,
        };

        //Line�o��
        lineRenderer.SetPositions(positions);

        Move(cursorPoint);
        TargetRot(cursorPoint);
    }
    public void MovetoBoss()
    {
        Move(boss);
        TargetRot(boss);
    }
    public void Attack()
    {
        TargetRot(boss);
    }



   


    public void Move(GameObject target)
    {

        TargetRot(target);


        transform.position += transform.forward * moveValue * Time.deltaTime;
    }



    public void TargetRot(GameObject target)
    {

        Vector3 vector = target.transform.position;

        vector.y = transform.position.y;

        Vector3 vec = vector - transform.position;

        // ��]�ʌv�Z
        Quaternion qutRot = Quaternion.LookRotation(vec.normalized);

        //�v���C���[�̉�]
        transform.rotation = Quaternion.Slerp(transform.rotation, qutRot, rotationValue * Time.deltaTime);


    }

    public void AIFlag()
    {
        if (canAttackFlag)
        {
            canAttackFlag = false;
        }
        else
        {
            canAttackFlag = true;
        }
    }

    public GameObject Getmpobj
    {
        get { return mpobj; }


    }
}