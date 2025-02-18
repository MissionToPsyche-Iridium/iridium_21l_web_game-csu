using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotateShip : MonoBehaviour
{   //declare variables
    public Vector2 turn;
    public GameObject shipCenter;
    private Rigidbody rb;


    public InputAction RotateQ;
    public InputAction RotateE;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RotateQ = InputSystem.actions.FindAction("RotateQ");
        RotateE = InputSystem.actions.FindAction("RotateE");
        rb = shipCenter.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = shipCenter.transform.localEulerAngles;
        //establish mouse input variables, and match horizontal mouse movement with ship's Z rotation
        turn.x = Input.GetAxis("Mouse X");
       
     
        turn.y = Input.GetAxis("Mouse Y");
    
        if (RotateQ.IsPressed())
        {
            transform.Rotate(0f, 0f, .25f);
        }
        if (RotateE.IsPressed())
        {
            transform.Rotate(0f, 0f, -.25f);
        }
       
        transform.Rotate(turn.y, turn.x, 0);
      

    }
}
