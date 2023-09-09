using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.X86.Sse4_2;

public class heal_bar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    [SerializeField]public GameObject shiled_;
    public GameObject shile_bar;
    private void Awake()
    {
       
    }
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
         shiled_ = load_skin.Inscetan.curren_skin();
    }

    // Update is called once per frame
    void Update() 
    {
        if (shiled_.activeSelf == true)
        {
            shile_bar.SetActive(true);   
            fill.color = new Color(0,1,0.9915812f,1);

        }
        else
        {
            shile_bar.SetActive(false);
            fill.color = gradient.Evaluate(slider.normalizedValue);
        }

    }
    public void Setheal(float health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    public void maxheal(float health)
    {
        slider.maxValue = health;
    slider.value = health;
    fill.color =gradient.Evaluate(1f);
    }
}
