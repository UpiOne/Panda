using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class setLi : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider volume;
    

    private void Start()
    {
        volume.value = PlayerPrefs.GetFloat("po");

    }

    public void SetLevel(float sliderValue)
    {
        PlayerPrefs.SetFloat("po", sliderValue);

        mixer.SetFloat("VfxVol", Mathf.Log10(sliderValue) * 20);

    }
}
