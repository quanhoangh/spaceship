using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] protected int movespeed = 1;
    [SerializeField] protected Vector3 direction = Vector3.right;
    [SerializeField] public float dislimti ;
    private float distace;
    // Start is called before the first frame update
    private void Awake()
    {
       
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction*movespeed*Time.deltaTime);
        de_spawn();
    }
    void de_spawn()
    {
        distace = Vector3.Distance(transform.position, transform.parent.position);
        if(distace > dislimti)
        {
     Destroy(gameObject);
        }   
      
    }
}
