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

        //それぞれの距離を測定
        float ptplength = Vector3.Distance(transform.position, cursorPoint.transform.position);
        float ptblength = Vector3.Distance(transform.position, boss.transform.position);

        //移動させる
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

        //ボスへ自動的に移動移動
        else if (ptblength >= attackRange && canActionFlag)
        {
            mode = playerMode.MovetoBoss;
        }

        //自動的に攻撃
        else if (canActionFlag)
        {
            mode = playerMode.Attack;
        }

        //停止
        else if (!canActionFlag)
        {
            mode = playerMode.Idle;
        }
    }
    public void TrueTargetFlag() { if (!moveFlag) { moveFlag = true; } }
}
