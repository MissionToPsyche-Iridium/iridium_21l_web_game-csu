using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreens : MonoBehaviour
{
    void Start() {
    Cursor.lockState = CursorLockMode.None;
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void TryAgain()
    {
        if (MainMenu.isEndlessMode)
        {
            SceneManager.LoadScene(8);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
}