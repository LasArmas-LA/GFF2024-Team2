using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCharacter : MonoBehaviour
{
    // 移動速度
    public float speed = 5.0f;

    //カメラのアニメーター
    public Animator charaAnimator;

    public bool charaStart = false;

    float timeCout = 0;

    [SerializeField]
    float startTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        charaStart = false;
        timeCout = 0;
    }
    void Update()
    {
        if(charaStart)
        {
            timeCout += Time.deltaTime;
        }
        

        if (timeCout >= startTime)
        {
            // 移動方向のベクトル（例: 前方）
            Vector3 direction = gameObject.transform.forward;

            // 移動量を計算
            Vector3 moveAmount = direction * speed * Time.deltaTime;

            // 位置を移動
            transform.Translate(moveAmount);
        }
        
    }

    public void StartCharacter()
    {
        charaAnimator.SetBool("BattleStart", true);
        BattleGo();
        //Invoke("BattleGo", 1.8f);
    }

    void BattleGo()
    {
        charaStart = true;
    }

}
