using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPoint : MonoBehaviour
{
    [SerializeField]
    private GameObject kensiObj = null;

    [SerializeField]
    private GameObject juusensiObj = null;


    private bool rayFlag = true;
    private float clickTime = 0.0f;
    void Update()
    {
        //ƒ}ƒEƒX“ü—Í‚Æ“¯Žž‚É‰Šú‰»
        if (Input.GetMouseButtonDown(0))
        {
            rayFlag = true;
            clickTime = 0.0f;
        }

        if (Input.GetMouseButton(0))
        {
            clickTime += Time.deltaTime;
            if(clickTime > 0.5f) { rayFlag = false; }


        }

        if (Input.GetMouseButtonUp(0) && rayFlag)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject.CompareTag("Ground"))
                {
                    kensiObj.GetComponent<Kenshi>().trueTargetFlag();
                    juusensiObj.GetComponent<Juusensi>().trueTargetFlag();

                    transform.position = new Vector3(hit.point.x, 0, hit.point.z);
                    rayFlag = true;
                    clickTime = 0.0f;
                }
                else
                {

                }
                
            }

        }
        
    }
}