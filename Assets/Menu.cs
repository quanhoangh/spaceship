using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    // paused
    public  GameObject  pausemenu;
    public bool isPaused;
    //game over
    public GameObject menuOver;
    public static Menu instance;
    private void Awake()
    {
        Menu.instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        pausemenu.SetActive(false);
        menuOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                resumeGame();
            }
            else
            {
                    pausegam();
            }
            
        }
        
    }
    public void pausegam()
    {
        pausemenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void resumeGame()
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void gameover()
    {
        menuOver.SetActive(true);
       pausemenu.SetActive(false);
        Time.timeScale = 0f;

    }
}
