using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class SelectPoint : MonoBehaviour
{
    [SerializeField]
    private GameObject player01Obj = null;

    [SerializeField]
    private GameObject player02Obj = null;

    [SerializeField]
    public GameObject[] cursorPoint = null;

    private bool CPFlag = false;


    void Awake()
    {
        cursorPoint[0].SetActive(false);
        cursorPoint[1].SetActive(false);
        cursorPoint[2].SetActive(false);
    }

    public bool SetCPFlag
    {
        set { CPFlag = value; }
    }
    public bool GetCPFlag
    {
        get { return CPFlag; }
    }

    void Update()
    {
        Player1 player1 = player01Obj.GetComponent<Player1>();
        Player2 player2 = player02Obj.GetComponent<Player2>();
        //Player3 player3 = player01Obj.GetComponent<Player3>();


        if (Input.GetMouseButtonDown(0) && (player1.GetMoveFlag || player2.GetMoveFlag))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.CompareTag("Ground"))
                {
                    CPFlag = true;
                    transform.position = new Vector3(hit.point.x, 0, hit.point.z);

                    if (player1.GetMoveFlag)
                    {
                        cursorPoint[0].SetActive(true);
                        player1.SetMoveFlag = false;
                    }
                    if (player2.GetMoveFlag)
                    {
                        cursorPoint[1].SetActive(true);
                        player1.SetMoveFlag = false;
                    }
                    //if (player3.GetMoveFlag)
                    //{
                    //    cursorPoint[2].SetActive(true);
                    //    player1.SetMoveFlag = false;
                    //}
                    Time.timeScale = 1f;

                }
                else
                {

                }
                
            }

        }
        
    }
}