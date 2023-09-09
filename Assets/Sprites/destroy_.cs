using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_ : MonoBehaviour
{
    [SerializeField] public float alline=1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,alline);
    }
}
