using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : PlayerBase
{
    private GameObject mpobj = null;
    // Start is called before the first frame update
    void Start()
    {
        mpobj = Getmpobj;
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
        if (ptplength >= positionRange && targetFlag)
        {
            mpobj.SetActive(true);
            mode = playerMode.MovetoTarget;
        }
        else if (targetFlag)
        {
            lineRenderer.enabled = false;
            mpobj.SetActive(false);
            targetFlag = false;
        }

        //�{�X�֎����I�Ɉړ��ړ�
        else if (ptblength >= attackRange && canAttackFlag)
        {
            mode = playerMode.MovetoBoss;
        }

        //�����I�ɍU��
        else if (canAttackFlag)
        {
            mode = playerMode.Attack;
        }

        //��~
        else if (!canAttackFlag)
        {
            mode = playerMode.Idle;
        }
    }

    public void TrueTargetFlag() { if (!targetFlag) { targetFlag = true; } }
}
