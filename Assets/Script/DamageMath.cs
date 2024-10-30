using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Threading.Tasks;

public class DamageMath : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI damageText = null;

    private int damage = 0;
    private int nowDamage = 0;

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    async void Update()
    {

        while (nowDamage < damage) 
        {
            await Task.Delay(10);
            nowDamage += 100;
            damageText.text = $"{nowDamage}";
        }

    }



    public void DamagePlus(int damagePlus)
    {
        damage += damagePlus;
    }
}
