using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Menu_gameOver : MonoBehaviour
{
    public TextMeshProUGUI text_coin;
    public TextMeshProUGUI text_wave;
    public TextMeshProUGUI text_time;
    public float time;
    private static Menu_gameOver instance;

    public static Menu_gameOver Instance { get => instance; }

    private void Awake()
    {
        Menu_gameOver.instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        data();
    }
    public void data()
    {
     int coin=   system_Secne_1.Instance.coin;
     int wave = system_Secne_1.Instance.wave;
        gui_on(coin, wave);
        time=Time.time;
    }
    private void gui_on(int coin,int wave)
    {
        text_coin.text = coin.ToString();
        text_wave.text ="Wave: "+ wave.ToString();

        text_time.text = "Time: "+ Mathf.Round(time *100)/100f;
    }
}
