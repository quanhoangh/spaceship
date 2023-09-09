using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conntroll_buff : MonoBehaviour
{
    public GameObject buff_potiton;
    public static conntroll_buff instance;
    private void Awake()
    {
      conntroll_buff.instance = this;
      
                buff_potiton = this.gameObject;
        
       
    }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
