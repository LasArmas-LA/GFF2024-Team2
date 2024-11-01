using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boss : BossBase
{
   

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
                Attack01();
            break;
            case bossMode.Attack02:
                Attack02();
            break;
        }
    }

    private void Idle()
    {
        Invoke("Attack01",5);
    }
    private void IdleToAttack01()
    {
        Invoke("Attack01", 5);
    }

    private void Attack01()
    {
        Quaternion quaternion = Quaternion.Euler(transform.forward);
        if(!attackFlag)
        {
            Instantiate(attack[0], attackPoint[0].transform.position, quaternion, attackParent.transform);
            attackFlag = true;
            //Invoke("Attack01collider", 5);
        }
        
       
    }

    

    private void Attack01collider()
    {

        Quaternion quaternion = Quaternion.Euler(transform.forward);

        Instantiate(damageArea[0], attackPoint[0].transform.position, quaternion, daParent.transform);

        mode = bossMode.Idle;
        attackFlag = false;
    }

    private void Attack02()
    {
        Quaternion quaternion = Quaternion.Euler(0,0,0);
        if (!attackFlag)
        {
            Instantiate(attack[1], attackPoint[1].transform.position, quaternion, attackParent.transform);
            attackFlag = true;
            Invoke("Attack02ToIdle", 5);
        }


    }



    private void Attack02ToIdle()
    {

        Quaternion quaternion = Quaternion.Euler(0,1,0);

        Instantiate(damageArea[1], attackPoint[1].transform.position, quaternion, daParent.transform);

        mode = bossMode.Idle;
        attackFlag = false;
    }
}
