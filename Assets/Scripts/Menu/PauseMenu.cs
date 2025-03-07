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
    public void PauseOn() {
        //MenuPanel.SetActive(true);
        //Cursor.lockState = CursorLockMode.Locked;
        isPaused = true;
        Time.timeScale = 0;
    }

    public void PauseOff() {
        //MenuPanel.SetActive(false);
        //Cursor.lockState = CursorLockMode.None;
        isPaused = false;
        Time.timeScale = 1;
    }
}
