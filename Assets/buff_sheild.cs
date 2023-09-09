using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buff_sheild : MonoBehaviour
{
    public GameObject shied;
    public bool shieding=false;
    private static buff_sheild intance;

    public static buff_sheild Intance { get => intance; }

    private void Awake()
    {

       
       

        if (shied == null)
        {
            return;
        }
        buff_sheild.intance = this;  
    }
    private void Start()
    {
    }
    private void Update()
    {
        shied = load_skin.Inscetan.curren_skin();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            shield.Instence.currbuff = 0;
            shied.SetActive(true);
            Destroy(gameObject);
        }
    }
}
