using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider volume;


    private void Start()
    {
        volume.value = PlayerPrefs.GetFloat("volume");
     
    }
 
    public void ToggleMusic(bool enabled)
    {
        if (enabled)
        {
            mixer.SetFloat("MusicVolume", 0);
        }
        else
        {
            mixer.SetFloat("MusicVolume", -80);
        }
    }
   
    public void SetLevel(float sliderValue)
    {
        PlayerPrefs.SetFloat("volume", sliderValue);
      
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
     
    }
}
