using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class system_Secne_1 : MonoBehaviour
{   

    public int coin=0;
    private int coin_curr;

    public int coin_dead =500;
    [SerializeField]  private static system_Secne_1 instance;
        public static system_Secne_1 Instance { get => instance; }
    public TextMeshProUGUI text_coin;
    public TextMeshProUGUI text_Wave;
    public float time;
   [SerializeField] public int wave=0;
    private void Awake()
    {
        system_Secne_1.instance = this;
        Time.timeScale = 1f;
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        coin_curr = coin;
        text_coin.text =coin_curr.ToString();
        text_Wave.text = "Wave :" + wave;
        time =Time.time;
    }
    public void coin_enmy()
    {
        coin += coin_dead;
    }
    public void next_wave()
    {
        wave += 1;
    }
    public void boss_coin()
    {
        coin += coin_dead * 3;
    }
    

}
