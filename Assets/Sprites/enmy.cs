using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enmy : MonoBehaviour
{
    [SerializeField] public float delay_shooting = 1f;
    [SerializeField] public float delay_shootime =0;
    [SerializeField] GameObject bullet_Enmy;
    [SerializeField] public float Dame_enmy;
    public GameObject Parent_enmy;

    private void Awake()
    {
        Parent_enmy = GameObject.Find("Parent_enmy");
    }
    // Start is called before the first frame update
    void Start()
    {
        
        if (Parent_enmy == null) return;
        Transform pos = Parent_enmy.transform;
        
        Instantiate(bullet_Enmy, transform.position, transform.rotation,pos);

    }

    // Update is called once per frame
    void Update()
    {
        shooting();
        transform.rotation = Quaternion.Euler(0, 0, -90);
    }
    
    private void shooting()
    {
        if (Parent_enmy == null) return;
        Transform pos = Parent_enmy.transform;
        

        delay_shootime += Time.deltaTime;
        if (delay_shooting > delay_shootime) return;
            delay_shootime = 0;    
        if (bullet_Enmy == null) { return; }
        Instantiate(bullet_Enmy, transform.position, transform.rotation,pos);
    }
}
