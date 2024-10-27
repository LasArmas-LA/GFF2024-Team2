using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbySys : MonoBehaviour
{
    [Header("ゲームオブジェクト")]

    //フェードインオブジェクト
    [SerializeField]
    GameObject feadInObj;

    //フェードインオブジェクト
    [SerializeField]
    GameObject feadOutObj;

    //カメラのアニメーター
    [SerializeField]
    Animator cameraAnimator;

    //カメラオブジェクト
    [SerializeField]
    GameObject cameraObj;

    [SerializeField]
    GameObject canvasDefault;


    bool battleFlag = false;
    bool illustratedBookFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        //カメラのアニメーター取得
        cameraAnimator = cameraObj.GetComponent<Animator>();



        //フェードイン処理
        feadInObj.SetActive(true);
        feadOutObj.SetActive(false);
        Invoke("FeadIn", 0.8f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //フェードイン処理
    void FeadIn()
    {
        feadInObj.SetActive(false);
    }

    //フェードイン処理
    void FeadOut()
    {
        feadOutObj.SetActive(true);
    }



    public void TitleButton()
    {
        if(battleFlag)
        {
            battleFlag = false;
            cameraAnimator.SetBool("BattleFlag", false);
            canvasDefault.SetActive(true);
        }
        else if (illustratedBookFlag)
        {
            illustratedBookFlag = false;
            cameraAnimator.SetBool("BookFlag", false);
            canvasDefault.SetActive(true);
        }
        else
        {
            Invoke("TitleTransition", 0.5f);
            feadOutObj.SetActive(true);
        }
        
        
    }

    void TitleTransition()
    {
        SceneManager.LoadScene("TitleScene");
    }

    //バトルアニメーション
    public void BattleAnim()
    {
        //カメラのバトルアニメーション再生
        cameraAnimator.SetBool("BattleFlag", true);
        battleFlag = true;

        canvasDefault.SetActive(false);
    }

    public void BattleDefaultAnim()
    {
        //カメラのバトルアニメーション戻る
        cameraAnimator.SetBool("BattleFlag", false);
    }

    public void BookAnim()
    {
        //カメラのバトルアニメーション戻る
        cameraAnimator.SetBool("BookFlag", true);
        illustratedBookFlag = true;

        canvasDefault.SetActive(false);
    }

    public void BookDefaultAnim()
    {
        //カメラのバトルアニメーション戻る
        cameraAnimator.SetBool("BookFlag", false);
    }
}
