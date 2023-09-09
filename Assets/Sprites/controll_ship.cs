using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class controll_ship : MonoBehaviour
{
    [SerializeField] protected Vector3 MousePosition;
    [SerializeField] protected float speed =0.1f ;
     public  bool LookAt=false;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {

            MousePosition = hit.point;
        }


        MousePo();

        moveMouse();
      


    }
    private void FixedUpdate()
    {


      

    
        
    }
    private void MousePo()
    {
/*        MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
*/        MousePosition.z = 0;
    }
    private void moveMouse()
    {
        Vector3 newPos =  Vector3.Lerp(transform.parent.position, MousePosition,speed);
        transform.parent.position = newPos;
    }
    private void _Look()
    {
        Vector3 diff = MousePosition - transform.parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y,diff.x)* Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z+90);
    }


    

}
