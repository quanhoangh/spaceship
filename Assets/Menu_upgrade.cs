using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu_upgrade : MonoBehaviour
{ 
    public  List<GameObject> skill_list_ =new List<GameObject>();
    public GameObject Menu_skin;
    public GameObject MenuUpgrade;
    public GameObject Menu_sound;
    public GameObject Menu_ship;
    public GameObject menu_info;
    public List<TextMeshProUGUI> pirce;
    private int coin;
    private int index;
    private Transform canva;
    public int coin_data;
    private static Menu_upgrade instace;
    public static Menu_upgrade Instace { get => instace; }

    public  List<propertie_powsUp> propertie_Pows =new List<propertie_powsUp>();
   
    private  Animator animator_ship;
    private void Awake()
    {
        
        Menu_upgrade.instace = this;
        onpen_game();
        foreach(Transform o in MenuUpgrade.transform)
        {
            if(o.gameObject.name!= "Panel")
           skill_list_.Add(o.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
              
    }

    // Update is called once per frame
    void Update()
    {
        coin = data.Inscetan.coin;
        upBarSkill();
        up_pice();
        if (Input.GetKeyDown(KeyCode.O)){
            for(int i = 0; i < 5; i++)
            {
            PlayerPrefs.DeleteKey("skill"+i);
            }
            
        }


        for(int i=0; i < 5; i++)
        {
            propertie_Pows[i].index_unlocked = PlayerPrefs.GetInt("skill" +i, 0);
            pirce[i].text = propertie_Pows[i].price.ToString();
            if (propertie_Pows[i].index_unlocked >= 4)
            {
                pirce[i].text = "max";
            }
        }
       
    }
    public void click_upgra(GameObject clickedButton)
    {
        index =skill_list_.IndexOf(clickedButton);
       coin_data= propertie_Pows[index].price;
        if (coin >= coin_data)
        {
            data.Inscetan.data_buy_skll();
        if (propertie_Pows[index].index_unlocked < 4)
        {
            propertie_Pows[index].index_unlocked += 1;
         PlayerPrefs.SetInt("skill"+index, propertie_Pows[index].index_unlocked) ;
        }
        }
        
    }
    public void openMenu_upgarde()
    {
         menu_info.SetActive(false);
        Menu_sound.SetActive(false);
        Menu_skin.SetActive(false);
        MenuUpgrade.SetActive(true);
    }
    public void closeMenu_upgarde()
    {
        menu_info.SetActive(false);
        Menu_sound.SetActive(false);
        Menu_skin.SetActive(true);
        MenuUpgrade.SetActive(false);
    }
    public void onpen_game()
    {
        menu_info.SetActive(false);
        Menu_sound.SetActive(false);
        MenuUpgrade.SetActive(false);
        Menu_ship.SetActive(false);
        animator_ship = Menu_ship.GetComponent<Animator>();
        canva = GameObject.Find("Canvas").transform;
        foreach (Transform o in canva)
        {
            if (o.gameObject.name == "Menu_skin")
            {
                Menu_skin = o.gameObject;
            }
            if(o.gameObject.name == "Menu_upgrade")
            {
                MenuUpgrade = o.gameObject;
            }
        }
    }
   
    private void upBarSkill()
    {  int a=0;
        pirce.Clear();
        foreach(GameObject o in skill_list_)
        {
           
            foreach (Transform bar in o.transform)
            {   
                if (bar.gameObject.name == "price")
                {
                    pirce.Add(bar.gameObject.GetComponentInChildren<TextMeshProUGUI>());
                }
               
                if(bar.gameObject.name == "bar")
                {
                    int i = 0;
                    
                    foreach(Transform B in bar.transform)
                    {
                        if (propertie_Pows[a].index_unlocked > i)
                        {
                            B.gameObject.GetComponent<Image>().color = Color.red;
                            
                        }
                       

                        i++;                           
                    }
                    a++;
                }
            }
        }
    }

    private void up_pice()
    {
        foreach(propertie_powsUp i in propertie_Pows)
        {
            if (i.index_unlocked == 0)
            {
                i.price = 500;
            }
            else if (i.index_unlocked == 1)
                i.price = 1250;
            else if (i.index_unlocked == 2)
            {
                i.price = 2250;
            }
            else if (i.index_unlocked == 3)
                i.price = 3000;            
        }
        
    }
    public void Open_menusound()
    {
        menu_info.SetActive(false);
        MenuUpgrade.SetActive(false);
        Menu_skin.SetActive(false);
        Menu_sound.SetActive(true);
    }
    public void Openmenu_ship()
    {
        if (Menu_ship.activeSelf)
        {
        animator_ship.SetTrigger("close");
            StartCoroutine(delay());
        
        
        }

        else
        {
             Menu_ship.SetActive(true);
            animator_ship.SetTrigger("open");
           
        }
       
        
    }
    public void openMenu_info()
    {
        MenuUpgrade.SetActive(false);
        Menu_skin.SetActive(false);
        Menu_sound.SetActive(false);
        menu_info.SetActive(true);
    }
    IEnumerator delay() {
        yield return new WaitForSeconds(0.7f) ;
        Menu_ship.SetActive(false);
    }
}
