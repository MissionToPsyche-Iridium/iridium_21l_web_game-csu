using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Events.UnityEvent.AddListener.html
//https://discussions.unity.com/t/proper-way-to-reference-scripts-in-unity/295021
public class InvertYAxis : MonoBehaviour {
    [SerializeField] Toggle InvertYAxisToggle;
    private void Awake() 
    {
        //loads saved state
        if (PlayerPrefs.HasKey("flipY")) {
            bool savedState = PlayerPrefs.GetInt("flipY") == 1;
            InvertYAxisToggle.isOn = savedState;
            RotateShip.flipY = savedState;
        }
    }
        public void Start() {
        //listens for change
        InvertYAxisToggle.onValueChanged.AddListener(OnToggleChanged);
    }

    void OnToggleChanged(bool isOn)
    {
        //update rotateship script
        RotateShip.flipY = isOn;
        //save state
        PlayerPrefs.SetInt("flipY", isOn ? 1 : 0);
        PlayerPrefs.Save();
    }
}