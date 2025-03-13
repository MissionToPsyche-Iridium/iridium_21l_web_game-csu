using UnityEngine;
using UnityEngine.InputSystem;
using System.Runtime.CompilerServices;
//https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Time-timeScale.html
//https://docs.unity3d.com/6000.0/Documentation/ScriptReference/EditorApplication-isPaused.html
//https://discussions.unity.com/t/need-help-with-pause-menu-and-cursor-lock-script-conflict/236567
public class PauseMenu : MonoBehaviour {
    public GameObject MenuPanel;
    public InputAction PauseGame;
    private bool isPaused = false;

void Start()
    {
        MenuPanel.SetActive(false);
        PauseGame.Enable();
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
            isPaused = !isPaused;
            MenuPanel.SetActive(isPaused);

            if (isPaused){
                Time.timeScale = 0;  //pause
                Cursor.lockState = CursorLockMode.Locked; //(isnt working)
            }
            else {
                Time.timeScale = 1;  //unpause
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}