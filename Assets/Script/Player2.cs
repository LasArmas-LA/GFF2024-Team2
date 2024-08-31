using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;



public class Juusensi : MonoBehaviour
{
    enum playerMode
    {
        Idle,
        MovetoTarget,
        MovetoBoss,
        Attack,
        Max,
    }
    playerMode mode = playerMode.Idle;



    [SerializeField]
    private GameObject cursorPoint = null;

    [SerializeField]
    private GameObject boss = null;



    [SerializeField]
    [Header("âÒì]ë¨ìx")]
    private float rotationValue = 0;

    [SerializeField]
    [Header("à⁄ìÆë¨ìx")]
    private float moveValue = 0;

    [SerializeField]
    [Header("ëIëÇµÇΩèäÇ∆í‚é~à íuÇ∆ÇÃãóó£")]
    private float positionRange = 0;

    [SerializeField]
    [Header("éÀíˆãóó£")]
    private float attackRange = 0;


    private GameObject mpobj = null;
    private bool canAttackFlag = false;
    private bool targetFlag = false;
    void Start()
    {

        mpobj = cursorPoint.transform.GetChild(0).gameObject;
        mpobj.SetActive(false);
    }

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
        float ptplength = Vector3.Distance(transform.position, cursorPoint.transform.position);
        float ptblength = Vector3.Distance(transform.position, boss.transform.position);
        if (ptplength >= positionRange && targetFlag)
        {
            mpobj.SetActive(true);
            mode = playerMode.MovetoTarget;
        }
        else if(targetFlag)
        {
            mpobj.SetActive(false);
            targetFlag = false;
        }
        else if (ptblength >= attackRange && canAttackFlag)
        {
            mode = playerMode.MovetoBoss;
        }
        else if(canAttackFlag)
        {
            mode = playerMode.Attack;
        }
        else if(!canAttackFlag)
        {
            mode = playerMode.Idle;
        }
    }

    private void Idle()
    {
        TargetRot(boss);
    }

    private void MovetoTarget()
    {
        Move(cursorPoint);
        TargetRot(cursorPoint);
    }
    private void MovetoBoss()
    {
        Move(boss);
        TargetRot(boss);
    }
    private void Attack()
    {
        TargetRot(boss);
    }



    public void trueTargetFlag(){ if (!targetFlag) {targetFlag = true;} }

   
    private void Move(GameObject target)
    {
        TargetRot(target);

        
        transform.position += transform.forward * moveValue * Time.deltaTime;
    }



    private void TargetRot(GameObject target)
    {

        Vector3 vector = target.transform.position;

        vector.y = transform.position.y;

        Vector3 vec =  vector - transform.position;

        // âÒì]ó åvéZ
        Quaternion qutRot = Quaternion.LookRotation(vec.normalized);

        //ÉvÉåÉCÉÑÅ[ÇÃâÒì]
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
   
}