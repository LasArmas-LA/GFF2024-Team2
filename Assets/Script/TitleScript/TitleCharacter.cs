using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCharacter : MonoBehaviour
{
    // �ړ����x
    public float speed = 5.0f;

    //�J�����̃A�j���[�^�[
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
            // �ړ������̃x�N�g���i��: �O���j
            Vector3 direction = gameObject.transform.forward;

            // �ړ��ʂ��v�Z
            Vector3 moveAmount = direction * speed * Time.deltaTime;

            // �ʒu���ړ�
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
