using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlay : MonoBehaviour
{
    void Start() {
    Cursor.lockState = CursorLockMode.None;
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}