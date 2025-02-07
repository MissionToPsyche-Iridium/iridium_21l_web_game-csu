using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] Slider Volume;
    public void Start()
    {
        if(!PlayerPrefs.HasKey("musicVolume")) {
            PlayerPrefs.SetFloat("musicVolume", 0.5f);
            Load();
        }
        else {
            Load();
        }
    }
    public void ChangeVolume() {
        AudioListener.volume = Volume.value;
    }

    public void Load() {
        Volume.value = PlayerPrefs.GetFloat("musicVolume");
    }

    public void Save() {
        PlayerPrefs.SetFloat("musicVolume", Volume.value);
    }
}