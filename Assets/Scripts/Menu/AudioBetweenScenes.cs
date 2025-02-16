using UnityEngine;
using UnityEngine.SceneManagement;
//https://docs.unity3d.com/6000.0/Documentation/ScriptReference/SceneManagement.SceneManager-sceneLoaded.html
public class AudioBetweenScenes : MonoBehaviour
{
    public static AudioBetweenScenes instance;
    private void Awake(){
        if(instance==null){
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else{
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (scene.name == "Game"){
            Destroy(gameObject);
        }
    }

    private void OnDestroy() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}