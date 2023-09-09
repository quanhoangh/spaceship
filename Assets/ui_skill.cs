using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ui_skill : MonoBehaviour
{
    [SerializeField] public UnityEngine.UI.Slider slider_laser;
   
    private void Awake()
    {
      slider_laser = GetComponent<UnityEngine.UI.Slider>();
    }
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
     void Update()
    {
        
    }
 public  void max_timeLaser(float time)
    {
        slider_laser.maxValue = time;
        slider_laser.value = time;
    }
    public void setTime_laser(float time)
    {
        slider_laser.value = time;
    }

}
