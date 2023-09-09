using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class boss : MonoBehaviour
{
    [SerializeField] public float delay_shooting = 1f;
    [SerializeField] public float delay_shootime = 0;
    [SerializeField] GameObject bullet_Enmy;
    [SerializeField] public float Dame_enmy;
    public GameObject Parent_enmy;
    public GameObject bullet_point;
    public GameObject player;
    Vector3 ros_player;
    public bool isSkill;
    float movedelay=0;

    private void Awake()
    {
        Parent_enmy = GameObject.Find("Parent_enmy");
       
    }
    // Start is called before the first frame update
    void Start()
    {

        if (Parent_enmy == null) return;
        Transform pos = Parent_enmy.transform;

 
        

    }

    // Update is called once per frame
    void Update()
    {
      transform.rotation=  Quaternion.Euler(0f, 0f, -180);
        if ((boss_hp.Instance.hp / boss_hp.Instance.maxHP) * 100<=75)
        {
            isSkill=true;
        }

        player = GameObject.FindWithTag("Player");
        move();
        if (isSkill)
            skill();
        else
        shooting();

        
    }

    private void shooting()
    {
        if (Parent_enmy == null) return;
        Transform pos = Parent_enmy.transform;


        delay_shootime += Time.deltaTime;
        if (delay_shooting > delay_shootime) return;
        delay_shootime = 0;
        if (bullet_Enmy == null) { return; }

        Instantiate(bullet_Enmy, bullet_point.transform.position, bullet_point.transform.rotation, pos);
    }

    private void skill()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, transform.position.y, transform.position.z), 2f * Time.deltaTime);
        if (Parent_enmy == null) return;
        Transform pos = Parent_enmy.transform;


        delay_shootime += Time.deltaTime;
        if (delay_shooting > delay_shootime) return;
        delay_shootime = 0;
        if (bullet_Enmy == null) { return; }
        for (int i = 0; i < 181; i += 15)
        {
            Quaternion ros = Quaternion.Euler(0f, 0f, -i);

            Instantiate(bullet_Enmy, bullet_point.transform.position, ros, pos);
        }
    }


    private void move()
    {
        delay_move();
        transform.position = Vector3.MoveTowards(transform.position,ros_player, 2f*Time.deltaTime);
    }

    void delay_move()
    {
       
        movedelay += Time.deltaTime;
        if (2.25 > movedelay) return;
        movedelay = 0;
        ros_player = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
    }
}
