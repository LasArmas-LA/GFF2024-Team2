using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBase : MonoBehaviour
{
    public enum bossMode
    {
        Charge,
        Idle,
        IdleToAttack01,
        IdleToAttack02,
        Attack01,
        Attack02,
        Max,
    }
    public bossMode mode = bossMode.Idle;

    [SerializeField]
    public GameObject[] attack;

    [SerializeField]
    public GameObject[] attackPoint;

    [SerializeField]
    public GameObject attackParent;

    [SerializeField]
    public GameObject[] damageArea;

    [SerializeField]
    public GameObject daParent;


    [SerializeField]
    [Header("ëÃóÕ")]
    public float bossHP;

    [SerializeField]
    [Header("ñhå‰óÕ")]
    public float bossDef;

    [SerializeField]
    [Header("çUåÇóÕ")]
    public float bossAtk;

    public bool attackFlag = false;

    public bool damageAreaFlag = false;



    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
