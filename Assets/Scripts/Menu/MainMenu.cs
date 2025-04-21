using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static bool isEndlessMode = false;
    public void PlayGame()
    {
        isEndlessMode = false;
        SceneManager.LoadScene(6);
    }
    public void PlayEndless()
    {
        isEndlessMode = true;
        SceneManager.LoadScene(8);
    }
    public void PlaySelectMode()
    {
        SceneManager.LoadScene(9);
    }
    public void OptionsGame()
    {
        SceneManager.LoadScene(2);
    }
     public void CreditsButton()
    {
        SceneManager.LoadScene(3);
    }
    public void HowToPlayButton()
    {
        SceneManager.LoadScene(7);
    }
    void Start() {
        Cursor.lockState = CursorLockMode.None;
    }
    public void Awake(){
        if (PlayerPrefs.HasKey("musicVolume")) {
        AudioListener.volume = PlayerPrefs.GetFloat("musicVolume");
        }
        else{
        AudioListener.volume = 1f;
        }
    }
}