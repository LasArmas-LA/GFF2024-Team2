using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;



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
    public GameObject damage = null;


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
    [Header("体力")]
    public float playerHP;

    [SerializeField]
    [Header("防御力")]
    public float playerDef;

    [SerializeField]
    [Header("攻撃力")]
    public float playerAtk;




    [SerializeField]
    public Material lineMaterial = null;

    //キャラ選択時処理用
    [SerializeField]
    public Material myMaterial = null;

    [SerializeField]
    public SpriteRenderer sprite = null;





    public bool canActionFlag = false;
    public bool moveFlag = false;
    public bool CPFlag = false;
    public bool attackedFlag = false;

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

        //Lineの位置を入力
        Vector3 startPos = this.transform.position;
        startPos.y = 0.1f;
        Vector3 endPos = moveTarget.transform.position;
        endPos.y = 0.1f;
        var positions = new Vector3[]
        {
            startPos,
            endPos,
        };

        //Line出力
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
        Damage();
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

    public virtual async void Damage()
    {
        DamageMath damageMath = damage.GetComponent<DamageMath>();
        if(!attackedFlag)
        {
            attackedFlag = true;
            damageMath.DamagePlus((int)playerAtk);
            await Task.Delay(1000);
            attackedFlag = false;
        }
    }


    //攻撃を行うために移動するかの切り替え
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
        Debug.Log("攻撃!!");
    }
}