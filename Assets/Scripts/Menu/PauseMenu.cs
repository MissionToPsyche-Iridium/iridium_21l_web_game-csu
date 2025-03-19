using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
//https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Time-timeScale.html
//https://docs.unity3d.com/6000.0/Documentation/ScriptReference/EditorApplication-isPaused.html
//https://discussions.unity.com/t/need-help-with-pause-menu-and-cursor-lock-script-conflict/236567
public class PauseMenu : MonoBehaviour {
    public GameObject MenuPanel;
    public GameObject ResumeButton;
    public GameObject BackButton;
    public InputAction PauseGame;
    private bool isPaused = false;

public void Resume() {
    isPaused = false;
    MenuPanel.SetActive(false);
    ResumeButton.SetActive(false);
    BackButton.SetActive(false);
    Time.timeScale = 1;
}
public void BackToMenu(){
    SceneManager.LoadScene(0);
    Time.timeScale = 1;
}
void Start(){
    Cursor.lockState = CursorLockMode.Locked;
    MenuPanel.SetActive(false);
    ResumeButton.SetActive(false);
    BackButton.SetActive(false);
    PauseGame.Enable();
}
private void OnEnable() {
    PauseGame.Enable();
}
private void OnDisable() {
    PauseGame.Disable();
}
void Update() {
    if (PauseGame.WasPressedThisFrame()){
        isPaused = !isPaused;
        MenuPanel.SetActive(isPaused);
        ResumeButton.SetActive(isPaused);
        BackButton.SetActive(isPaused);

        if (isPaused){
            Time.timeScale = 0;  //pause
            Cursor.lockState = CursorLockMode.None;
        }
        else {
            Time.timeScale = 1;  //unpause
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
}