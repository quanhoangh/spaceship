using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class menu_ship : MonoBehaviour
{
    public List<TextMeshProUGUI> shipList;

    private void Awake()
    {
        foreach (Transform o in transform) {
            shipList.Add(o.GetComponent<TextMeshProUGUI>());

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shipList[0].text = "hp: " +data_ship.Inscetan.hp;
        shipList[1].text = "damege: " + data_ship.Inscetan.dame;
        shipList[2].text = "cooldown skill: " + data_ship.Inscetan.coldown;
        shipList[3].text = "shield lifetime: " + data_ship.Inscetan.shiled_time;
        shipList[4].text = "damege skill: " + data_ship.Inscetan.dame_skill;
    }
}
