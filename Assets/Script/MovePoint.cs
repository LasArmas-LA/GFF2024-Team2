using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPoint : MonoBehaviour
{
    [SerializeField]
    private GameObject player01Obj = null;

    [SerializeField]
    private GameObject player02Obj = null;

    [SerializeField]
    private GameObject player03Obj = null;

    [SerializeField]
    public GameObject[] cursorPoint = null;

    [SerializeField]
    private LayerMask layermask = 6; 

    private bool CPFlag = false;


    void Awake()
    {
        cursorPoint[0].SetActive(false);
        cursorPoint[1].SetActive(false);
        cursorPoint[2].SetActive(false);
    }

    

    void Update()
    {
        Player1 player1 = player01Obj.GetComponent<Player1>();
        Player2 player2 = player02Obj.GetComponent<Player2>();
        Player3 player3 = player03Obj.GetComponent<Player3>();


        if (Input.GetMouseButtonDown(0) && (player1.GetMoveFlag || player2.GetMoveFlag || player3.GetMoveFlag))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100f,layermask))
            {
                if (hit.collider.gameObject.CompareTag("Ground"))
                {

                    if (player1.GetMoveFlag)
                    {
                        Time.timeScale = 1f;
                        cursorPoint[0].transform.position = new Vector3(hit.point.x, 0, hit.point.z);
                        cursorPoint[0].SetActive(true);
                        player1.SetMoveFlag = false;
                        player1.SetCPFlag = true;
                    }
                    if (player2.GetMoveFlag)
                    {
                        Time.timeScale = 1f;
                        cursorPoint[1].transform.position = new Vector3(hit.point.x, 0, hit.point.z);
                        cursorPoint[1].SetActive(true);
                        player2.SetMoveFlag = false;
                        player2.SetCPFlag = true;
                    }
                    if (player3.GetMoveFlag)
                    {
                        Time.timeScale = 1f;
                        cursorPoint[2].transform.position = new Vector3(hit.point.x, 0, hit.point.z);
                        cursorPoint[2].SetActive(true);
                        player3.SetMoveFlag = false;
                        player3.SetCPFlag = true;
                    }


                }
                else
                {

                }
                
            }

        }
        
    }
}