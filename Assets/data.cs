using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class data : MonoBehaviour
{
   [SerializeField]    private static data inscetan;
   [SerializeField] public static data Inscetan { get => inscetan;}

    //data
    public int coin=0;
    public int wave=0;
    public float time=0;
    public int coin_cur;

    
    private void Awake()
    {
        data.inscetan = this;
        loadData();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyUp(KeyCode.O)) {
        reset_data();
        }
    }
    private void FixedUpdate()
    {
        
                upd_data();
               
        
    }
    public void loadData()
    {

        Data_Save data = system_Save.loadData();
        if (data == null) return;
        coin = data.coin_data;
        wave = data.wave_data;
        time = data.time_data;
    }
    public void saveData()
    {
        coin += coin_cur;
        system_Save.data_save(this);
    }
    public void upd_data()
    {
        
        if (system_Secne_1.Instance == null) return;
        
        coin_cur = system_Secne_1.Instance.coin;
        wave = system_Secne_1.Instance.wave;
        time =system_Secne_1.Instance.time;
        
        
    }
    public void reset_data()
    {
        coin = 0;
        wave = 0;
        time = 0;
        saveData();

    }
    public void data_buy()
    {
        coin -= system_menu.Inscetan.c.price;
        saveData() ;
    }
    public void data_buy_skll()
    {
        coin -= Menu_upgrade.Instace.coin_data;
    }
}
