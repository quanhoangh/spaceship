using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser_controll : MonoBehaviour
{
    [SerializeField] public float dame_bullet ;
    [SerializeField] protected GameObject Hit_;
    public void send_dame(Transform obj)
    {
        enmy_HP Dame_ = obj.GetComponentInChildren<enmy_HP>();
        if (Dame_ == null) return;
        send_dame(Dame_);
    }
    public virtual void send_dame(enmy_HP Dame_)
    {
        dame_bullet = laser_skill.instance.Dame_lear;
        Dame_.Deduct(dame_bullet);
        Instantiate(Hit_, transform.position, transform.rotation);

        if (Hit_ == null) { return; }

    }
    public void send_dame_boss(Transform obj)
    {
        boss_hp Dame_ = obj.GetComponentInChildren<boss_hp>();
        if (Dame_ == null) return;
        send_dame_boss(Dame_);
    }
    public virtual void send_dame_boss(boss_hp Dame_)
    {
        dame_bullet = laser_skill.instance.Dame_lear;
        Dame_.Deduct(dame_bullet);
        Instantiate(Hit_, transform.position, transform.rotation);

        if (Hit_ == null) { return; }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        send_dame(collision.transform);
        send_dame_boss(collision.transform);

    }

}
