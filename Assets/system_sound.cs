using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class system_sound : MonoBehaviour
{
    private static readonly string string_background = "sound_background";
    private static readonly string string_eff = "sound_eff";

    public float value_soundBG;
    public float value_eff;
    public Slider sound_BG_bar;
    public Slider sound_eff_bar;
   
    public AudioSource sound_background;
    public List<AudioSource> sound_eff;
    void Start()
    {   
       value_soundBG= PlayerPrefs.GetFloat(string_background,0.25f);
       value_eff= PlayerPrefs.GetFloat (string_eff,0.25f);
        sound_BG_bar.value = value_soundBG;
        sound_eff_bar.value = value_eff;
        
    }

    // Update is called once per frame
    private void Update()
    {
        sound_ud();
    }
    private void sound_ud()
    {
        sound_background.volume = sound_BG_bar.value;
        foreach (AudioSource source in sound_eff)
        {
            source.volume = sound_eff_bar.value;
        }
        PlayerPrefs.SetFloat(string_background, sound_BG_bar.value);
        PlayerPrefs.SetFloat(string_eff, sound_eff_bar.value);
    }
}
