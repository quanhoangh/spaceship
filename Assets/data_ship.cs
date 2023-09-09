using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class data_ship : MonoBehaviour
{
    public float hp;
    public float dame;
    public float coldown;
    public float dame_skill;
    public float shiled_time;

    public List<int> index;
    private static data_ship inscetan;

    public static data_ship Inscetan { get => inscetan;  }
    private void Awake()
    {
       data_ship.inscetan = this;
        upd_data();
    }

    // Start is called before the first frame update
    void Start()
    {

/*        Debug.Log(SceneUtility.GetBuildIndexByScenePath(SceneManager.GetActiveScene().path));
*/          
    }

    // Update is called once per frame
    void Update()
    {
        upd_data();
    }

    public void upd_data()
    {
       for (int i = 0; i < 5; i++) {

            index[i] = PlayerPrefs.GetInt("skill"+i, 0);
           
        }
        hp_();
        dame_();
        coldown_();
        dame_skill_();
        shile_();
        
    }
    public void hp_() {
        if (index[0] == 0) hp = 10;
        if (index[0] == 1) hp = 15;
        if (index[0] == 2) hp = 17;
        if (index[0] == 3) hp = 20;
        if (index[0] == 4) hp = 25;
    }
    public void dame_()
    {
        if (index[1] == 0) dame = 5;
        if (index[1] == 1) dame = 7;
        if (index[1] == 2) dame = 10;
        if (index[1] == 3) dame = 15;
        if (index[1] == 4) dame = 20;
    }
    public void coldown_()
    {
        if (index[2] == 0) coldown = 6f;
        if (index[2] == 1) coldown = 5.5f;
        if (index[2] == 2) coldown = 5.25f;
        if (index[2] == 3) coldown = 4.5f;
        if (index[2] == 4) coldown = 4f;
    }
    public void dame_skill_()
    {
        if (index[3] == 0) dame_skill = 4;
        if (index[3] == 1) dame_skill = 7;
        if (index[3] == 2) dame_skill = 9;
        if (index[3] == 3) dame_skill = 12;
        if (index[3] == 4) dame_skill = 15;
    }
    public void shile_()
    {
        if (index[4] == 0) shiled_time = 5;
        if (index[4] == 1) shiled_time = 5.5f;
        if (index[4] == 2) shiled_time = 5.75f;
        if (index[4] == 3) shiled_time = 6f;
        if (index[4] == 4) shiled_time = 6.5f;
    }
}
