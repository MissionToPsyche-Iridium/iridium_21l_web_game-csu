using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour {
    [SerializeField] Slider Volume;
    public void Awake() {
        if(!PlayerPrefs.HasKey("musicVolume")) { //volume set at 50% if there isn't one set already by the player
            PlayerPrefs.SetFloat("musicVolume", .5f);
            Load();
        }
        else { //if it is already set, load that value instead
            Load(); 
        }
    }
    public void ChangeVolume() {
        AudioListener.volume = Volume.value;
        Save();
    }

    public void Load() {
        Volume.value = PlayerPrefs.GetFloat("musicVolume"); //uses playerprefs to load value
    }

    public void Save() {
        PlayerPrefs.SetFloat("musicVolume", Volume.value); //saves value with playerprefs
    }
}