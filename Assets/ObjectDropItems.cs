using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 [System.Serializable]
public class loot
{

    public GameObject Item;
    [Range(0.1f, 100f)]
    public float dropRate;
    public int minQuntity;
    public int maxQuntity;

}
public class ObjectDropItems : MonoBehaviour
{
    public loot[] loots;
    
    private void Update()
    { 
    }

    public void DropIitem()
    {   
        int a = 0;
        foreach (loot loot in loots)
        {
            
            a++;
            float spawnChance = Random.Range(0.1f, 100f);
            if(spawnChance <= loot.dropRate)
            {
                int spwanAmount = Random.Range(loot.maxQuntity, loot.minQuntity);
                for(int i = 0; i < spwanAmount; i++)
                {
                       spawn(loot);
                   
                }
                 return;
            }
           
        }
            return;
    }
    public void spawn(loot loot)
    {

       
        Instantiate(loot.Item,transform.position, Quaternion.Euler(0, 0, 0));
  
    }
}

    
