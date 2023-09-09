using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser_skill : MonoBehaviour
{
    public GameObject bullet;
    public float delay_skill;
    public float time_skill;
    public float time_laser;
    float time_;
    public float Dame_lear;
    public static laser_skill instance;
    public bool isSkill=false;
    public ui_skill ui;
    public float time_UI =0f;
    private int i;
    private GameObject o;
    private void Awake()
    {
        laser_skill.instance = this;
        time_ = 0;
        
    }
    private void Start()
    {
        delay_skill = data_ship.Inscetan.coldown;
        Dame_lear = data_ship.Inscetan.dame_skill;
        ui.max_timeLaser(delay_skill);
    }
    private void Update()
    {

        ui.setTime_laser(time_UI);
        if(time_UI >= 0)
        {
            time_UI -=Time.deltaTime;
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
         
           if (Time.time > time_skill)
            {
            isSkill = true;
            time_UI = delay_skill;
            time_skill =Time.time +delay_skill ;
            }          
        }      
            skill_();
            
    }
    private void FixedUpdate()
    {

    }
    void skill_()
    {
        
            if (isSkill)
            {
            {
                time_ += Time.deltaTime;
                if (time_ < time_laser)
                {
                    bullet_spwan();
                }
                else
                {
                    
                    isSkill = false;
                    time_ = 0;
                    i = 0;             
                    Destroy( o );
                }
            }
        }
    }
    void bullet_spwan()
    {
        
        if(i<=0)
      o=  Instantiate(bullet, transform.position, transform.rotation, transform);
      i++;

    }
 
}
