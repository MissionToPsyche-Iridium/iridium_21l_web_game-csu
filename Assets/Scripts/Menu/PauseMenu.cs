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
    public GameObject player;
    private bool isPaused = false;

public void Resume() { //when player resumes, isPaused becomes false, the cursor does not show up, the buttons do not function, and the timescale is set back to 1
    isPaused = false;
    Cursor.lockState = CursorLockMode.Locked;
    player.GetComponent<RotateShip>().enabled = true;
    MenuPanel.SetActive(false);
    ResumeButton.SetActive(false);
    BackButton.SetActive(false);
    Time.timeScale = 1;
}
public void BackToMenu(){ //if player clicks back to menu button, they go back to the menu
    SceneManager.LoadScene(0);
    Time.timeScale = 1;
}
void Start(){ //default is timescale 1, the cursor is not displayed, and the menu buttons are not present
    Time.timeScale = 1;
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
void Update() { //if paused, the menu shows up and the timescale is stopped. the players cursor also shows up in order to press the buttons and the game won't let you rotate the ship
    if (PauseGame.WasPressedThisFrame()){
        isPaused = !isPaused;
        MenuPanel.SetActive(isPaused);
        ResumeButton.SetActive(isPaused);
        BackButton.SetActive(isPaused);

        if (isPaused){
            Time.timeScale = 0;  //pause
            Cursor.lockState = CursorLockMode.None;
            player.GetComponent<RotateShip>().enabled = false;
            }
        else {
            Time.timeScale = 1;  //unpause
            Cursor.lockState = CursorLockMode.Locked;
            player.GetComponent<RotateShip>().enabled = true;
            }
    }
}
}