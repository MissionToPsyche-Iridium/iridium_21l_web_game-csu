using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour {
    [SerializeField] Slider Volume;
    public void Awake() {
        if(!PlayerPrefs.HasKey("musicVolume")) {
            PlayerPrefs.SetFloat("musicVolume", 1f);
            Load();
        }
        else {
            Load();
        }
    }
    public void ChangeVolume() {
        AudioListener.volume = Volume.value;
        Save();
    }

    public void Load() {
        Volume.value = PlayerPrefs.GetFloat("musicVolume");
    }

    public void Save() {
        PlayerPrefs.SetFloat("musicVolume", Volume.value);
    }
    private void OnApplicationQuit() {
        Save();
    }
}