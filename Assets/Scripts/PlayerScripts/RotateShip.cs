using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotateShip : MonoBehaviour
{   //declare variables
    public Vector2 turn;
    public GameObject shipCenter;
    private Rigidbody rb;
    public static bool flipY = false; //Dylan
    public static float sensitivity = 1f; //Dylan 
    public InputAction RotateQ;
    public InputAction RotateE;
    public Rigidbody lockedRotateRB;
    private float waitTime = 1f;
    private float timer = 0.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //set vars
        RotateQ = InputSystem.actions.FindAction("RotateQ");
        RotateE = InputSystem.actions.FindAction("RotateE");
        rb = shipCenter.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {   
        //rotation var is equal to current players rotation, then enable mouse input for camera and q/e camera if not in cutscene
        Vector3 rotation = shipCenter.transform.localEulerAngles;
        if (spawnScript.cutscene)
        {
            RotateE.Disable();
            RotateQ.Disable();
        }
        else
        {
            RotateE.Enable();
            RotateQ.Enable();
            turn.x = Input.GetAxis("Mouse X");

            turn.y = Input.GetAxis("Mouse Y");
        }
        
        //if q/e is pressed than rotate, and then calculate mouse movement for player with an option for inverted Y axis.
        if (RotateQ.IsPressed())
        {
            transform.Rotate(0f, 0f, 75f  * Time.deltaTime);
        }
        if (RotateE.IsPressed())
        {
            transform.Rotate(0f, 0f, -75f * Time.deltaTime);
        }
        if (RotateShip.flipY == false)
        {
            transform.Rotate(-turn.y * (2*sensitivity + .1f), turn.x * (2 * sensitivity + .1f), 0);
        }
        if (RotateShip.flipY == true)
        {
            transform.Rotate(turn.y * (2 * sensitivity + .1f) , turn.x * (2 * sensitivity + .1f), 0);
        }

        //QOL, if not mouse input, reset back to center
        if (!RotateQ.IsPressed() && !RotateE.IsPressed() && turn.x == 0 && turn.y == 0)
        {
            timer += Time.deltaTime;
            if (timer > waitTime)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, lockedRotateRB.rotation, Time.deltaTime);
            }
                
        }
        else
        {
            timer = 0;
        }
      

    }
}
