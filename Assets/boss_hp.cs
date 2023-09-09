using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_hp : MonoBehaviour
{
    [SerializeField] public float hp = 10f;
    [SerializeField] public float maxHP;
    public float deylay_time = 0;
    public float deylay = 0.01f;
    private static boss_hp instance;
    public int i = 0;
    Animator animator;

    public static boss_hp Instance { get => instance; }

    private void Awake()
    {
        boss_hp.instance = this;
        animator = GetComponent<Animator>();
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
            if (i <= 0)
            {
                death();
            }

        }


    }

    private void death()
    {
        i++;
        system_Secne_1.Instance.boss_coin();
        lv_controll.Instace.next_LV();
        GetComponent<ObjectDropItems>().DropIitem();
        animator.SetTrigger("dead");
        deylay_time += Time.deltaTime;
        if (deylay_time < deylay) return;
        else
        {
            deylay_time = 0;
            StartCoroutine(deading());
        }

    }

    public void hp_bouns()
    {
        hp += system_Secne_1.Instance.wave * 100;
    }

    IEnumerator deading()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}
