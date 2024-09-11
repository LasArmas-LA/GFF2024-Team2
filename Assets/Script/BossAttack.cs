using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class BossAttack : MonoBehaviour
{


    private bool attackFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("SpawnDamageArea", 5);
    }

    private void SpawnDamageArea()
    {
        

    }
}
