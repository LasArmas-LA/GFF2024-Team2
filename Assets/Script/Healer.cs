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
            //待機
            case playerMode.Idle:
                Idle();
                break;
            //選択した位置に移動
            case playerMode.MovetoTarget:
                MovetoTarget();
                break;
            //ボスへ移動
            case playerMode.MovetoBoss:
                MovetoBoss();
                break;
            //自動で攻撃
            case playerMode.Attack:
                Attack();
                break;
        }

        //それぞれの距離を測定
        float ptplength = Vector3.Distance(transform.position, moveTarget.transform.position);
        float ptblength = Vector3.Distance(transform.position, boss.transform.position);

        SelectPoint point = movePoint.GetComponent<SelectPoint>();
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

            moveTarget.SetActive(false);

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

        canvas.transform.rotation = defRot;
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
        SelectPoint point = movePoint.GetComponent<SelectPoint>();
        Debug.Log(moveFlag);
    }

    public override void Skils()
    {
        Debug.Log("スキル：タンク");
    }
}
