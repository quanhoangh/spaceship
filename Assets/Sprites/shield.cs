using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield : MonoBehaviour
{ 
    private static shield instence;
    private Animator animator;
    public float deylay=0.3f;
    public float deylay_time=0;
    public float time_buff=2f;  
    public float currbuff = 0f;


    public static shield Instence { get => instence; }

    private void Awake()
    {
        animator = GetComponent<Animator>(); 
        shield.instence = this;
        

    }
    // Start is called before the first frame update
    void Start()
    {
        time_buff = data_ship.Inscetan.shiled_time;
    }

    // Update is called once per frame
    void Update()
    {
        shielding();
    }
    private void FixedUpdate()
    {
    }

    private void death()
    {
         deylay_time +=Time.time;
        animator.SetTrigger("dead");
        if (deylay_time < deylay) return;
        else
        {
            deylay_time = 0;
            gameObject.SetActive(false);
        }
    }

  public  void shielding ()
    {
        currbuff += Time.deltaTime;
        if (currbuff < time_buff) return;
        else
        {
            currbuff = 0;
            death();
        }
    }
}
