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
        SceneManager.LoadScene(1);
    }
}