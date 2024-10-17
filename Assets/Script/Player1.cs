using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player1 : PlayerBase
{
    private void Awake()
    {
        mpobj = cursorPoint.transform.GetChild(0).gameObject;

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
        float ptplength = Vector3.Distance(transform.position, mpobj.transform.position);
        float ptblength = Vector3.Distance(transform.position, boss.transform.position);

        SelectPoint point = cursorPoint.GetComponent<SelectPoint>();
        //移動させる
        if (ptplength >= positionRange && point.GetCPFlag)
        {
            mode = playerMode.MovetoTarget;
        }
        //目的地を入力でフラグfalse
        else if (ptplength <= positionRange && point.GetCPFlag)
        {
            mode = playerMode.Idle;

            lineRenderer.enabled = false;

            mpobj.SetActive(false);

            point.SetCPFlag = false;

        }

        //攻撃フラグtrueでボスへ自動的に移動
        else if (ptblength >= attackRange && canActionFlag)
        {
            mode = playerMode.MovetoBoss;
        }

        //自動的に攻撃
        else if (canActionFlag)
        {
            mode = playerMode.Attack;
        }

        //待機状態
        else if (!canActionFlag)
        {
            mode = playerMode.Idle;
        }

        DebugLogOutput();
    }

    //プレイヤーがキャラクターを移動させる時の演出切り替え
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
        SelectPoint point = cursorPoint.GetComponent<SelectPoint>();
        Debug.Log(point.GetCPFlag);
    }

    public override void Skils()
    {

    }
}
