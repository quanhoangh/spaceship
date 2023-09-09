using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class system_Save 
{
    public static void data_save(data data_load)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/data1.fun";
        FileStream stream = new FileStream(path, FileMode.Create);
        Data_Save data = new Data_Save(data_load);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static Data_Save loadData()
    {
        string path = Application.persistentDataPath + "/data1.fun";
        if(File.Exists(path))
        {
            BinaryFormatter formatter =new BinaryFormatter();
            FileStream stream =new FileStream(path, FileMode.Open);
            Data_Save data_  = formatter.Deserialize(stream) as Data_Save;
            stream.Close();
            return data_;
        }
        else
        {
            Debug.Log("" + path);
            return null;
        }
    }
}
