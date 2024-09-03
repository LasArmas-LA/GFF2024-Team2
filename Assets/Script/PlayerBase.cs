using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase
{
    public float playerHP;
    public float attack;
    public float attackSpeed;
    public float movSpeed;
    public float Defense;
    public float rotSpeed;
    public float skill01Delay;
    public float skill02Delay;
    public float ultimateDelay;
    public virtual void  Skill01()
    {
    }
    public virtual void Skill02()
    {
    }
    public virtual void Ultimate()
    { 
    }

}
