using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hp_main : MonoBehaviour
{
    [SerializeField] public float hpMain =10f;
    [SerializeField] public float hp_max;
    [SerializeField] public GameObject death_main;
    [SerializeField] public float alinetime=1;
    [SerializeField] public heal_bar heal_Bar;
    public GameObject shield;
    private int i=0;
    private void Awake()
    {
        shield = GameObject.Find("Shield");
      
    }
    // Start is called before the first frame update
    void Start()
    {
        hpMain = data_ship.Inscetan.hp;
        hp_max = hpMain;
        heal_Bar.maxheal(hp_max);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void Deduct(float deduct)
    {
        if (shield.activeSelf != true)
        {
        hpMain -= deduct;
        heal_Bar.Setheal(hpMain);
        if (hpMain < 0) 
                if(i == 0)
                {
                    death();
                    i++;
                }
                
        }
      
       

    }

    public void death()
    {
        data.Inscetan.saveData();
        Menu.instance.gameover();
        Instantiate(death_main, transform.position, transform.rotation);
        Destroy(gameObject, alinetime);
    }
}
