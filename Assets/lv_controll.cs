using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class lv_controll : MonoBehaviour
{
    public List<GameObject> Lv = new List<GameObject>();
    Transform clone_lv;
    int nunber_curr =0;
    public int i=0;
    public GameObject boss;
    public Transform point_spawn;

    private static lv_controll instace;

    public static lv_controll Instace { get => instace;  }

    private void Awake()
    {
        lv_controll.instace = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        foreach(Transform child in transform)
        {
          GameObject o= child.gameObject;          
                     Lv.Add(o);
            child.gameObject.SetActive(false);
        }
        clone_lv = GameObject.Find("clone_lv").transform;
    }

    // Update is called once per frame
    void Update()
    {
        check_lv();
    }
    private void FixedUpdate()
    {
        
            
            

    }
    void check_lv()
    {
        if (GameObject.Find("enmy(Clone)") != null)
        {
            i = 0;
             return;
        }
        else
        {
            if(system_Secne_1.Instance.wave == 5|| system_Secne_1.Instance.wave == 10 || system_Secne_1.Instance.wave == 15 || system_Secne_1.Instance.wave == 25 || system_Secne_1.Instance.wave == 30 || system_Secne_1.Instance.wave == 35 || system_Secne_1.Instance.wave == 40)
            {
            
                Instantiate(boss, point_spawn.position, transform.rotation);
                system_Secne_1.Instance.next_wave();
               
            }
            
            
            if(i==0)
                {
              next_LV();
                }
            
           
        

        }
           
       
            
        
    }
    public void next_LV()
    {
       
       

        i++;
        system_Secne_1.Instance.next_wave();
       
        if(nunber_curr >= Lv.Count)
        {
            nunber_curr=Lv.Count-1;
            
                random_LV();
            
            
        }
       
            Lv[nunber_curr].gameObject.SetActive(true);
            nunber_curr ++;

    }
    void random_LV()
    {
       
        int a = Random.Range(0, Lv.Count);

        Instantiate(Lv[a], Lv[a].gameObject.transform.position, transform.rotation,clone_lv);
    }
 
}
