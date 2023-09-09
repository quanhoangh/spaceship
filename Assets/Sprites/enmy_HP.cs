using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enmy_HP : MonoBehaviour
{
    [SerializeField] public float hp;
    [SerializeField] public float maxHP;
    [SerializeField] protected GameObject boomm;
    public float deylay = 0.01f;
    public float deylay_time = 0;
    public static enmy_HP instance;
    public int i=0;
    private void Awake()
    {
        enmy_HP.instance = this;    
    }
    // Start is called before the first frame update
    void Start()
    {
        hp_bouns();
        maxHP = hp;
       
    }

    // Update is called once per frame
    void Update()
    {
  
    }
    public void Deduct(float deduct) 
    {
        hp -= deduct;
        if (hp < 0)
        {
            if (i<=0)
            {
                death();
            }
       
        }
       

    }

    private void death()
    {
        i++;
        system_Secne_1.Instance.coin_enmy();
        if(boomm!= null)
        {
         Instantiate(boomm, pos_(), transform.rotation);
        }
       
        GetComponent<ObjectDropItems>().DropIitem();
        deylay_time += Time.deltaTime;
        if (deylay_time < deylay) return;
        else
        {
            deylay_time = 0;
            gameObject.SetActive(false);
        }

    }
    public void hp_bouns()
    {
        hp += system_Secne_1.Instance.wave *1 ;
    }
    public Vector3 pos_()
    {
        Vector3 pos = transform.position;
        return pos;
    }
}
