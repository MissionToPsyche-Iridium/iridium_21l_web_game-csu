using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static bool isEndlessMode = false;
    public void PlayGame() // play story mode
    {
        isEndlessMode = false;
        SceneManager.LoadScene(6);
    }
    public void PlayEndless() // play endless mode
    {
        isEndlessMode = true;
        SceneManager.LoadScene(8);
    }
    public void PlaySelectMode() //start
    {
        SceneManager.LoadScene(9);
    }
    public void OptionsGame() //options
    {
        SceneManager.LoadScene(2);
    }
     public void CreditsButton() //credits
    {
        SceneManager.LoadScene(3);
    }
    public void HowToPlayButton() //how to play
    {
        SceneManager.LoadScene(7);
    }
    void Start() { //make sure cursor is visible again after player exits to menu while paused
        Cursor.lockState = CursorLockMode.None;
    }
    public void Awake(){ //play volume at 50% unless player has otherwise set in options
        if (PlayerPrefs.HasKey("musicVolume")) {
        AudioListener.volume = PlayerPrefs.GetFloat("musicVolume");
        }
        else{
        AudioListener.volume = .5f;
        }
    }
}