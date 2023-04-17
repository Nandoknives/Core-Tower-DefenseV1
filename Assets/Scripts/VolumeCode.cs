using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeCode : MonoBehaviour
{
    public Slider slider;
    public float sliderValue = 0.5f;
    public Image imagenMute;



    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumeAudio", 0.5f);
        AudioListener.volume = slider.value;
        CheckIfMute();
    }

    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumeAudio", sliderValue);
        AudioListener.volume = slider.value;
        CheckIfMute();
    }




    public void CheckIfMute()
    {
        if(sliderValue==0)
        {
            imagenMute.enabled = true;
        }
        else
        {
            imagenMute.enabled = false;
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
