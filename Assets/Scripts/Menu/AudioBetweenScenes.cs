using UnityEngine;
using UnityEngine.SceneManagement;
// References: https://docs.unity3d.com/6000.0/Documentation/ScriptReference/SceneManagement.SceneManager-sceneLoaded.html
// This script allows the Music to play without restarting from scene to scene. It is attatched to the DontDestroyOnLoad so that it can go between scenes.

public class AudioBetweenScenes : MonoBehaviour
{
    public static AudioBetweenScenes instance;
    private void Awake(){ //default unity method that activates when the game starts and this script is active in the scene
        if(instance==null){ //check for first time load
            instance = this;
            DontDestroyOnLoad(gameObject); //keep object when loading into new scenes
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else{
            Destroy(gameObject); //if object is set, destroy so that only one instance plays at a time
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (scene.name == "Game" || scene.name == "EndlessMode"){ 
            Destroy(gameObject); //audio should stop when player starts the game (presses start)
        }
    }

    private void OnDestroy() { //method called when object is destoryed
        SceneManager.sceneLoaded -= OnSceneLoaded; //prevents memory leaks by unsubscribing from OnSceneLoaded
    }
}