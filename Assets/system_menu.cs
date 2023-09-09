using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class system_menu : MonoBehaviour
{
    public List<GameObject> skin_list = new List<GameObject>();
    public int coin;
    public TextMeshProUGUI text_coin;
    public GameObject buy_ask;
    public GameObject Menu_skin;
    public int currentSkin;
    public List<skin_propertie> skins = new List<skin_propertie>();
    public GameObject UI_skin_buy;
    public skin_propertie c;
    private static system_menu inscetan;
    public GameObject button;
    public AudioSource audio_buy;
    public static system_menu Inscetan { get => inscetan;}

    private void Awake()
    {
        
      
        system_menu.inscetan = this;
        if(buy_ask == null)
        {
            buy_ask = GameObject.Find("buy_ask");
        }
        
        buy_ask.SetActive(false);


        GameObject O = GameObject.Find("skin");
                   
        foreach (Transform skin in O.transform)
        {
            if ("lookSkin_bar" != skin.name) { 
            skin_list.Add(skin.gameObject);
            
        }
            }
            
       
        
        
    }
    // Start is called before the first frame update
    void Start()
    {
        skin_srart();
    }

    // Update is called once per frame
    void Update()
    {
        up_data();
        updUIBuy();
        if (Input.GetKeyDown(KeyCode.O)){

            PlayerPrefs.DeleteKey("current skin");
            foreach(skin_propertie s in skins)
            {
                PlayerPrefs.SetInt(s.name, 0);
                s.isUnlocked = false;
            }
        }
    }
    //Menu skin next
    public void next_Right()
    {
        skin_list[currentSkin].gameObject.SetActive(false);
        currentSkin++;
        if (currentSkin == skin_list.Count)
            currentSkin = 0;
            skin_list[currentSkin].SetActive(true);
        c = skins[currentSkin];
        if (!c.isUnlocked)
            return;
        
        PlayerPrefs.SetInt("current skin", currentSkin);
    }
    public void next_Left()
    {
        skin_list[currentSkin].gameObject.SetActive(false);
        currentSkin--;
        if (currentSkin == -1)
            currentSkin = skin_list.Count -1;
        skin_list[currentSkin].SetActive(true);
        c = skins[currentSkin];
        if (!c.isUnlocked)
            return;
        PlayerPrefs.SetInt("current skin", currentSkin);
    }

    //Menu ask buy
    public void buy_menu()
    {
        buy_ask.SetActive(true);
    }
    public void buy_false()
    {
        buy_ask.SetActive(false);
    }
   

    public void up_data()
    {
        coin = data.Inscetan.coin;
        text_coin.text = coin.ToString();
    }


    public void skin_srart()
    {
        currentSkin = PlayerPrefs.GetInt("current skin",0);
        foreach(GameObject skin in skin_list)
        {
            skin.SetActive(false);
        }
        skin_list[currentSkin].SetActive(true);

        foreach(skin_propertie skin in skins)
        {
            if(skin.price ==0)
                skin.isUnlocked = true;
            else
                skin.isUnlocked = PlayerPrefs.GetInt(skin.name,0)==0 ?false :true;
        }
    }
    private void updUIBuy()
    {
         c= skins[currentSkin];
       
        if(c.isUnlocked)
        {
            UI_skin_buy.SetActive(false) ;
            skin_list[currentSkin].GetComponent<Image>().color = new Color(1,1,1);
            button.SetActive(true);
        }
        else
        {
            UI_skin_buy.GetComponentInChildren<TextMeshProUGUI>().text = "" + c.price;
            UI_skin_buy.SetActive(true);
            skin_list[currentSkin].GetComponent<Image>().color = new Color(0, 0, 0);
            button.SetActive(false);

        }
    }
    public void unlook()
    {
         c = skins[currentSkin];
        
       
        if (coin >= c.price)
        {
        c.isUnlocked = true;
       buy_ask.SetActive(false);
        data.Inscetan.data_buy();
        PlayerPrefs.SetInt(c.name, 1);
        PlayerPrefs.SetInt("current skin", currentSkin);
            
            audio_buy.Play();
        }
        else
        {
            Debug.Log("ko du tien");
        }
    }
}
