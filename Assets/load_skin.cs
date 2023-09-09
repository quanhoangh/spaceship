using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class load_skin : MonoBehaviour
{
    public int currentSkin;
    public List<GameObject> skin_list =new List<GameObject>();
    private static load_skin inscetan;

    public static load_skin Inscetan { get => inscetan; }

    private void Awake()
    {
        load_skin.inscetan = this;   
        foreach(Transform o in transform)
        {
            skin_list.Add(o.gameObject);
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

    }
    public void skin_srart()
    {
        currentSkin = PlayerPrefs.GetInt("current skin", 0);
        foreach (GameObject skin in skin_list)
        {
            skin.SetActive(false);
        }
        skin_list[currentSkin].SetActive(true);

    }
    public GameObject curren_skin()
    {
        currentSkin = PlayerPrefs.GetInt("current skin", 0);
        GameObject o = skin_list[currentSkin];
        foreach(Transform skin in o.transform)
        {
            if ("Shield" == skin.name)
            {
                return skin.gameObject;
            }
        }
      return null;
    }
}
