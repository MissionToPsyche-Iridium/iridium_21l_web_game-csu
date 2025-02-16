using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//https://discussions.unity.com/t/proper-way-to-reference-scripts-in-unity/295021
public class SensitivitySlider : MonoBehaviour {
    [SerializeField] Slider Sensitivity;
    public void Awake() {
        Sensitivity.value = PlayerPrefs.GetFloat("sensitivity", 10f);
        Load();
    }
    public void ChangeSensitivity() {
        PlayerPrefs.SetFloat("sensitivity", Sensitivity.value);
        PlayerPrefs.Save();
        RotateShip.sensitivity = Sensitivity.value;
        Save();
    }

    public void Load() {
        Sensitivity.value = PlayerPrefs.GetFloat("sensitivity");
        RotateShip.sensitivity = Sensitivity.value;
    }

    public void Save() {
        PlayerPrefs.SetFloat("sensitivity", Sensitivity.value);
        PlayerPrefs.Save();
    }
    private void OnApplicationQuit() {
        Save();
    }
}