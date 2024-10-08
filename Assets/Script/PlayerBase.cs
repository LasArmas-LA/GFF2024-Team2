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
    [Header("回転速度")]
    public float rotationValue = 0;

    [SerializeField]
    [Header("移動速度")]
    public float moveValue = 0;

    [SerializeField]
    [Header("選択した所と停止位置との距離")]
    public float positionRange = 0;

    [SerializeField]
    [Header("射程距離")]
    public float attackRange = 0;

    [SerializeField]
    [Header("線の太さ")]
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

        //Lineの位置を入力
        Vector3 startPos = this.transform.position;
        startPos.y = 0.1f;
        Vector3 endPos = cursorPoint.transform.position;
        endPos.y = 0.1f;
        var positions = new Vector3[]
        {
            startPos,
            endPos,
        };

        //Line出力
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

        // 回転量計算
        Quaternion qutRot = Quaternion.LookRotation(vec.normalized);

        //プレイヤーの回転
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