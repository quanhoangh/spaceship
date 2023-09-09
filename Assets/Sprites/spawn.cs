using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class spawn : MonoBehaviour
{
    [SerializeField] public GameObject spawnGameObject_Enmy;
/*    [SerializeField] public float random_x=1;
    [SerializeField] public float random_Y=6;*/
    [SerializeField] public List<Transform> point;
    public int i;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (i < 3)
            spawning();
        
        
    }
    void spawning()
    {
      
       
          i++;   
        Transform posRand = random();
        Vector3 pos = posRand.position;
        Quaternion ros = spawnGameObject_Enmy.transform.rotation;
        if (spawnGameObject_Enmy == null) return;
        Instantiate(spawnGameObject_Enmy,pos,ros);
       
    }
    public virtual void loadPoint()
    {
        if (point.Count > 0) return;
        foreach (Transform Point in point)
        {
            point.Add(Point);
        }
    }
   public virtual Transform random()
    {
        int rand = UnityEngine.Random.Range(0,point.Count);
        return point[rand];
        
    }
}
