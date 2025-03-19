using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
     public void OptionsGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
     public void CreditsButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit.");
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