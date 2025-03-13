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
    private float ranX, ranY, ranSpeed = 0.0f;
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
        
        //establish mouse input variables, and match horizontal mouse movement with ship's Z rotation
        


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
