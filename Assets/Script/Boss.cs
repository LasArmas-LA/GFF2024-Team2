using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boss : MonoBehaviour
{
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

                break;
        }
    }

    private void Idle()
    {
        Invoke("IdleToAttack01",2);
    }
    private void IdleToAttack01()
    {
        mode = bossMode.Attack01;
    }

    private void Attack01()
    {

    }

}
