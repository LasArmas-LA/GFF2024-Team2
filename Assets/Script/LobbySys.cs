using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbySys : MonoBehaviour
{
    [Header("�Q�[���I�u�W�F�N�g")]

    //�t�F�[�h�C���I�u�W�F�N�g
    [SerializeField]
    GameObject feadInObj;

    //�t�F�[�h�C���I�u�W�F�N�g
    [SerializeField]
    GameObject feadOutObj;

    //�J�����̃A�j���[�^�[
    [SerializeField]
    Animator cameraAnimator;

    //�J�����I�u�W�F�N�g
    [SerializeField]
    GameObject cameraObj;

    [SerializeField]
    GameObject canvasDefault;


    bool battleFlag = false;
    bool illustratedBookFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        //�J�����̃A�j���[�^�[�擾
        cameraAnimator = cameraObj.GetComponent<Animator>();



        //�t�F�[�h�C������
        feadInObj.SetActive(true);
        feadOutObj.SetActive(false);
        Invoke("FeadIn", 0.8f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�t�F�[�h�C������
    void FeadIn()
    {
        feadInObj.SetActive(false);
    }

    //�t�F�[�h�C������
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

    //�o�g���A�j���[�V����
    public void BattleAnim()
    {
        //�J�����̃o�g���A�j���[�V�����Đ�
        cameraAnimator.SetBool("BattleFlag", true);
        battleFlag = true;

        canvasDefault.SetActive(false);
    }

    public void BattleDefaultAnim()
    {
        //�J�����̃o�g���A�j���[�V�����߂�
        cameraAnimator.SetBool("BattleFlag", false);
    }

    public void BookAnim()
    {
        //�J�����̃o�g���A�j���[�V�����߂�
        cameraAnimator.SetBool("BookFlag", true);
        illustratedBookFlag = true;

        canvasDefault.SetActive(false);
    }

    public void BookDefaultAnim()
    {
        //�J�����̃o�g���A�j���[�V�����߂�
        cameraAnimator.SetBool("BookFlag", false);
    }
}
