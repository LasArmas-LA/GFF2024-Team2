using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boss : MonoBehaviour
{
    [SerializeField]
    private GameObject attack01;

    [SerializeField]
    private GameObject attack01Point;

    [SerializeField]
    private GameObject attackParent;

    [SerializeField]
    private GameObject damageArea;

    [SerializeField]
    private GameObject daParent;


    private bool attack01Flag = false;

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
                Attack01();
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
        if(!attack01Flag)
        {
            Instantiate(attack01,  attack01Point.transform.position, quaternion, attackParent.transform);
            attack01Flag = true;
            Invoke("Attack01TOIdle", 5);
        }
        
       
    }

    

    private void Attack01TOIdle()
    {

        Quaternion quaternion = Quaternion.Euler(transform.forward);

        Instantiate(damageArea, attack01Point.transform.position, quaternion, daParent.transform);

        mode = bossMode.Idle;
        attack01Flag = false;
    }
    

}
