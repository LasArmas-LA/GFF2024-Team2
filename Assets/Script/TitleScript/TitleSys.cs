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




        //フェードイン処理
        feadInObj.SetActive(true);
        feadOutObj.SetActive(false);
        Invoke("FeadIn", 0.8f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //スタートボタン
    public void StartButton()
    {

        Invoke("Starttransition", 4.5f);
        Invoke("FeadOut", 3.5f);
    }

    //ゲーム終了ボタン
    public void ExitButton()
    {
        //ゲーム終了処理
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    //ロビーに遷移
    void Starttransition()
    {
        SceneManager.LoadScene("LobbyScene");
    }

    //フェードイン処理
    void FeadIn()
    {
        feadInObj.SetActive(false);
    }


    //フェードアウト処理
    void FeadOut()
    {
        feadOutObj.SetActive(true);
    }
}
