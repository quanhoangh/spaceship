using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ray_boss : MonoBehaviour
{
    [SerializeField] public float Dame_enmy = 1;
    [SerializeField] public GameObject hit_enmy;
    private GameObject Parent_enmy;
    
    // Start is called before the first frame update
    private void Awake()
    {
        Parent_enmy = GameObject.Find("Parent_enmy");
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(destros());

    }
    public void send_dame(Transform obj)
    {
        hp_main Dame_ = obj.GetComponentInChildren<hp_main>();
        if (Dame_ == null) return;
        send_dame(Dame_);
    }
    public virtual void send_dame(hp_main Dame_)
    {
        Transform par = Parent_enmy.transform;
        Dame_.Deduct(Dame_enmy);
        Instantiate(hit_enmy, transform.position, transform.rotation, par);

        if (hit_enmy == null) { return; }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        send_dame(collision.transform);

    }

    IEnumerator destros()
    {
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
