using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbySys : MonoBehaviour
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

    //�t�F�[�h�C������
    void FeadIn()
    {
        feadInObj.SetActive(false);
    }



    public void TitleButton()
    {
        Invoke("TitleTransition", 0.5f);
        feadOutObj.SetActive(true);
    }

    void TitleTransition()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
