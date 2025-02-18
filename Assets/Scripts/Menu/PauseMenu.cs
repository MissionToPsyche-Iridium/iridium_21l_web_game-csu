using UnityEngine;
using UnityEngine.InputSystem;
using System.Runtime.CompilerServices;
//https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Time-timeScale.html
//https://docs.unity3d.com/6000.0/Documentation/ScriptReference/EditorApplication-isPaused.html
//https://discussions.unity.com/t/need-help-with-pause-menu-and-cursor-lock-script-conflict/236567
//https://docs.unity3d.com/530/Documentation/ScriptReference/Screen-showCursor.html
public class PauseMenu : MonoBehaviour {
    public GameObject MenuPanel;
    public InputAction PauseGame;
    private bool isPaused = false;

void Start()
    {
        PauseGame = InputSystem.actions.FindAction("PauseGame");
    }
    private void OnEnable()
    {
        PauseGame.Enable();
    }
    private void OnDisable()
    {
        PauseGame.Disable();
    }
    void Update() {
        //Debug.Log("HELP!");
        if (PauseGame.WasPressedThisFrame()){
            if (isPaused){
                PauseOff();
                Debug.Log("Unpause");
            }
            else{
                PauseOn();
                Debug.Log("Pause");
            }
        }
    }

    public void PauseOff() { //Normal
        //MenuPanel.SetActive(false);
        //Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = false; //Gets rid of cursor when playing?? Might not be useful for Web Games.
        isPaused = false;
        Time.timeScale = 1;
    }

    public void PauseOn() { //Paused
        //MenuPanel.SetActive(true);
        //Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = true; //Brings cursor back for pause menu
        isPaused = true;
        Time.timeScale = 0;
    }
}
