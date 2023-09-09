using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data_Save 
{
    public int coin_data;
    public int wave_data;
    public float time_data;
   
    public Data_Save(data data)
    {
        coin_data = data.coin;
        wave_data = data.wave;
        time_data = data.time;
    }
}
