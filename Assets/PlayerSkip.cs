using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class PlayerSkip : MonoBehaviour
{
    public InputAction moveSpace;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveSpace = InputSystem.actions.FindAction("MoveSpace");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moveSpace.IsPressed())
        {
            SceneManager.LoadScene(1);
        }
    }
}
