using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : PlayerBase
{
    private void Awake()
    {
        mpobj = cursorPoint.transform.GetChild(0).gameObject;

        canActionFlag = false;
        moveFlag = false;

        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.material = lineMaterial;
    }
    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
       

        switch (mode)
        {
            case playerMode.Idle:
                Idle();
                break;

            case playerMode.MovetoTarget:
                MovetoTarget();
                break;

            case playerMode.MovetoBoss:
                MovetoBoss();
                break;

            case playerMode.Attack:
                Attack();
                break;
        }

        //���ꂼ��̋����𑪒�
        float ptplength = Vector3.Distance(transform.position, cursorPoint.transform.position);
        float ptblength = Vector3.Distance(transform.position, boss.transform.position);

        //�ړ�������
        if (ptplength >= positionRange && moveFlag)
        {

            mode = playerMode.MovetoTarget;
        }
        else if (moveFlag)
        {
            lineRenderer.enabled = false;
            mpobj.SetActive(false);
            moveFlag = false;
        }

        //�{�X�֎����I�Ɉړ��ړ�
        else if (ptblength >= attackRange && canActionFlag)
        {
            mode = playerMode.MovetoBoss;
        }

        //�����I�ɍU��
        else if (canActionFlag)
        {
            mode = playerMode.Attack;
        }

        //��~
        else if (!canActionFlag)
        {
            mode = playerMode.Idle;
        }
    }
    public void TrueTargetFlag() { if (!moveFlag) { moveFlag = true; } }
}
