using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boss : BossBase
{
    [SerializeField]
    private GameObject[] attack;

    [SerializeField]
    private GameObject[] attackPoint;

    [SerializeField]
    private GameObject attackParent;

    [SerializeField]
    private GameObject damageArea;

    [SerializeField]
    private GameObject daParent;


    private bool attackFlag = false;

    private bool damageAreaFlag = false;



    enum bossMode
    {
        Charge,
        Idle,
        Attack01,
        Attack02,
        Max,
    }
    bossMode mode = bossMode.Idle;

    private Vector3 mov = new Vector3 (5, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += mov * Time.deltaTime;
        //if(transform.position.x >=15) { transform.position = new Vector3(-15, 0, 10);  }

        switch (mode) 
        {
            case bossMode.Charge:
                Idle();
            break;
            case bossMode.Idle:
                Idle();
            break;
            case bossMode.Attack01:
                Attack02();
            break;
        }
    }

    private void Idle()
    {
        Invoke("IdleToAttack01",5);
    }
    private void IdleToAttack01()
    {
        mode = bossMode.Attack01;
    }

    private void Attack01()
    {
        Quaternion quaternion = Quaternion.Euler(transform.forward);
        if(!attackFlag)
        {
            Instantiate(attack[0], attackPoint[0].transform.position, quaternion, attackParent.transform);
            attackFlag = true;
            Invoke("Attack01ToIdle", 5);
        }
        
       
    }

    

    private void Attack01TOIdle()
    {

        Quaternion quaternion = Quaternion.Euler(transform.forward);

        Instantiate(damageArea, attackPoint[0].transform.position, quaternion, daParent.transform);

        mode = bossMode.Idle;
        attackFlag = false;
    }

    private void Attack02()
    {
        Quaternion quaternion = Quaternion.Euler(0,0,1);
        if (!attackFlag)
        {
            Instantiate(attack[1], attackPoint[1].transform.position, quaternion, attackParent.transform);
            attackFlag = true;
            Invoke("Attack02ToIdle", 5);
        }


    }



    private void Attack02ToIdle()
    {

        Quaternion quaternion = Quaternion.Euler(0,-1,0);

        Instantiate(damageArea, attackPoint[1].transform.position, quaternion, daParent.transform);

        mode = bossMode.Idle;
        attackFlag = false;
    }
}
