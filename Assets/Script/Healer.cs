using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3 : PlayerBase
{

    private Quaternion defRot;
    private void Awake()
    {
        moveTarget.SetActive(false);
        canActionFlag = false;
        moveFlag = false;

        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.material = lineMaterial;


        buttonText.text = "Standing By";

        lineRenderer.enabled = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        defRot = canvas.transform.rotation;
    }





    // Update is called once per frame
    void Update()
    {
        switch (mode)
        {
            //�ҋ@
            case playerMode.Idle:
                Idle();
                break;
            //�I�������ʒu�Ɉړ�
            case playerMode.MovetoTarget:
                MovetoTarget();
                break;
            //�{�X�ֈړ�
            case playerMode.MovetoBoss:
                MovetoBoss();
                break;
            //�����ōU��
            case playerMode.Attack:
                Attack();
                break;
        }

        //���ꂼ��̋����𑪒�
        float ptplength = Vector3.Distance(transform.position, moveTarget.transform.position);
        float ptblength = Vector3.Distance(transform.position, boss.transform.position);

        SelectPoint point = movePoint.GetComponent<SelectPoint>();
        //�ړ�������
        if (ptplength >= positionRange && point.GetCPFlag)
        {
            mode = playerMode.MovetoTarget;
        }
        //�ړI�n����͂Ńt���Ofalse
        else if (ptplength <= positionRange && point.GetCPFlag)
        {
            mode = playerMode.Idle;

            lineRenderer.enabled = false;

            moveTarget.SetActive(false);

            point.SetCPFlag = false;

        }

        //�U���t���Otrue�Ń{�X�֎����I�Ɉړ�
        else if (ptblength >= attackRange && canActionFlag)
        {
            mode = playerMode.MovetoBoss;
        }

        //�����I�ɍU��
        else if (canActionFlag)
        {
            mode = playerMode.Attack;
        }

        //�ҋ@���
        else if (!canActionFlag)
        {
            mode = playerMode.Idle;
        }

        DebugLogOutput();

        canvas.transform.rotation = defRot;
    }

    //�v���C���[���L�����N�^�[���ړ������鎞�̉��o�؂�ւ�
    public void ChangeMove()
    {
        if (!moveFlag)
        {
            Time.timeScale = 0.1f;
            moveFlag = true;
        }
        else
        {
            moveFlag = false;

            mode = playerMode.Idle;
        }
    }

    private void DebugLogOutput()
    {
        SelectPoint point = movePoint.GetComponent<SelectPoint>();
        Debug.Log(moveFlag);
    }

    public override void Skils()
    {
        Debug.Log("�X�L���F�^���N");
    }
}
