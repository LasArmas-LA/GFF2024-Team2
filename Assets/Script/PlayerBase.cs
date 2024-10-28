using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



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
    public GameObject movePoint = null;

    [SerializeField] 
    public GameObject moveTarget = null;

    [SerializeField]
    public GameObject boss = null;

    [SerializeField]
    public TextMeshProUGUI buttonText = null;

    [SerializeField]
    public Canvas canvas = null;


    [SerializeField]
    [Header("‰ñ“]‘¬“x")]
    public float rotationValue = 0;

    [SerializeField]
    [Header("ˆÚ“®‘¬“x")]
    public float moveValue = 0;

    [SerializeField]
    [Header("‘I‘ğ‚µ‚½Š‚Æ’â~ˆÊ’u‚Æ‚Ì‹——£")]
    public float positionRange = 0;

    [SerializeField]
    [Header("Ë’ö‹——£")]
    public float attackRange = 0;

    [SerializeField]
    [Header("ü‚Ì‘¾‚³")]
    public float lineWidth = 0;

    [SerializeField]
    [Header("‘Ì—Í")]
    public float playerHP;

    [SerializeField]
    [Header("–hŒä—Í")]
    public float playerDef;

    [SerializeField]
    [Header("UŒ‚—Í")]
    public float playerAtk;




    [SerializeField]
    public Material lineMaterial = null;

    //ƒLƒƒƒ‰‘I‘ğˆ——p
    [SerializeField]
    public Material myMaterial = null;

    [SerializeField]
    public SpriteRenderer sprite = null;





    public bool canActionFlag = false;
    public bool moveFlag = false;
    public bool CPFlag = false; 

    [SerializeField]
    public LineRenderer lineRenderer = null;



    public GameObject GetmoveTarget
    {
        get { return moveTarget; }
    }


    public bool SetMoveFlag
    {
        set { moveFlag = value; }
    }

    public bool GetMoveFlag
    {
        get { return moveFlag; }
    }

    public bool SetCPFlag
    {
        set { CPFlag = value; }
    }
    public bool GetCPFlag
    {
        get { return CPFlag; }
    }


    public void Idle()
    {

        TargetRot(boss);
    }

    


    public void MovetoTarget()
    {


        buttonText.text = "Moving now";
        canActionFlag = false;
        if (lineRenderer.enabled == false) { lineRenderer.enabled = true; }

        //Line‚ÌˆÊ’u‚ğ“ü—Í
        Vector3 startPos = this.transform.position;
        startPos.y = 0.1f;
        Vector3 endPos = moveTarget.transform.position;
        endPos.y = 0.1f;
        var positions = new Vector3[]
        {
            startPos,
            endPos,
        };

        //Lineo—Í
        lineRenderer.SetPositions(positions);

        Move(moveTarget);
        TargetRot(moveTarget);
    }

    public void MovetoBoss()
    {
        Move(boss);
        TargetRot(boss);
    }

    public virtual void Attack()
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

        // ‰ñ“]—ÊŒvZ
        Quaternion qutRot = Quaternion.LookRotation(vec.normalized);

        //ƒvƒŒƒCƒ„[‚Ì‰ñ“]
        transform.rotation = Quaternion.Slerp(transform.rotation, qutRot, rotationValue * Time.deltaTime);


    }


    //UŒ‚‚ğs‚¤‚½‚ß‚ÉˆÚ“®‚·‚é‚©‚ÌØ‚è‘Ö‚¦
    public void AIFlag()
    {
        if (canActionFlag)
        {
            canActionFlag = false;
        }
        else
        {
            canActionFlag = true;
        }
    }


    
    

    public virtual void Skils()
    {
        Debug.Log("UŒ‚!!");
    }
}