using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unity_controll : MonoBehaviour
{
    [SerializeField] public List<GameObject> unity_clone;
    public static unity_controll instance;
    private void Awake()
    {
       unity_controll.instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
       if(unity_clone.Count <=0)
        {
     add_untiy();
        }
    }
    void add_untiy()
    {
        foreach (Transform child in transform)
        {
            
            unity_clone.Add(child.gameObject);
            
        }
    }
    public void Destroy_unit()
    {
        foreach (GameObject unit in unity_clone)
        {
            Destroy(unit);
        }
        unity_clone.Clear();
    }
}
