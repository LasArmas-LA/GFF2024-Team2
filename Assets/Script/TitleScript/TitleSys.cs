using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSys : MonoBehaviour
{
    [SerializeField]
    GameObject feadInObj;

    [SerializeField]
    GameObject feadOutObj;


    // Start is called before the first frame update
    void Start()
    {




        //�t�F�[�h�C������
        feadInObj.SetActive(true);
        feadOutObj.SetActive(false);
        Invoke("FeadIn", 0.8f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //�X�^�[�g�{�^��
    public void StartButton()
    {

        Invoke("Starttransition", 4.5f);
        Invoke("FeadOut", 3.5f);
    }

    //�Q�[���I���{�^��
    public void ExitButton()
    {
        //�Q�[���I������
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    //���r�[�ɑJ��
    void Starttransition()
    {
        SceneManager.LoadScene("LobbyScene");
    }

    //�t�F�[�h�C������
    void FeadIn()
    {
        feadInObj.SetActive(false);
    }


    //�t�F�[�h�A�E�g����
    void FeadOut()
    {
        feadOutObj.SetActive(true);
    }
}
