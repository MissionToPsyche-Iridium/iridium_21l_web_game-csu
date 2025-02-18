using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
public class MoveShip : MonoBehaviour
{
    public GameObject shipCenter;
    public InputAction moveW;
    public InputAction moveS;
    public InputAction moveA;
    public InputAction moveD;
    //Created moveSpace input action
    public InputAction moveShift;
    public InputAction moveSpace;
    public InputAction moveCtrl;
    public Rigidbody shipBody;
    public static float shipSpeed = 5;
    public static float shipVariableSpeed = 0f;
    private bool isBoosted = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveW = InputSystem.actions.FindAction("MoveW");
        moveS = InputSystem.actions.FindAction("MoveS");
        moveA = InputSystem.actions.FindAction("MoveA");
        moveD = InputSystem.actions.FindAction("MoveD");
        moveShift = InputSystem.actions.FindAction("MoveShift");
        moveSpace = InputSystem.actions.FindAction("MoveSpace");
        moveCtrl = InputSystem.actions.FindAction("MoveCtrl");
    }

    // Update is called once per frame
    void Update()
    {
        //https://www.youtube.com/watch?v=7NMsVub5NZM
        //Debug.Log(shipBody.linearVelocity.magnitude);
        //Debug.Log(shipSpeed);
        if (!isBoosted) 
        { 
            shipBody.linearVelocity = Vector3.ClampMagnitude(shipBody.linearVelocity, 5f); 
        }
        shipVariableSpeed = shipBody.linearVelocity.magnitude;
    }
    void FixedUpdate()
    {
        if (moveW.IsPressed())
        { 
            shipBody.AddForce(transform.forward * shipSpeed);
        }
        if (moveS.IsPressed())
        { 
            shipBody.AddForce(-transform.forward * shipSpeed);
        }
        if (moveA.IsPressed())
        {   
            shipBody.AddForce(-transform.right * shipSpeed);
        }
        if (moveD.IsPressed())
        {   
            shipBody.AddForce(transform.right * shipSpeed);
        }
        if (moveSpace.IsPressed())
        {
            shipBody.AddForce(transform.up * shipSpeed);
        }
        if (moveCtrl.IsPressed())
        {          
            shipBody.AddForce(-transform.up * shipSpeed);
        }
        //Created new bit so it boosts whenever keys F and space-bar are both pressed at same time
        if (moveW.IsPressed() && moveShift.IsPressed())
        {
            isBoosted = true;
            shipSpeed += .25f;
            shipSpeed = Mathf.Clamp(shipSpeed, 0f, 5f);
            shipBody.linearVelocity = Vector3.ClampMagnitude(shipBody.linearVelocity, 9f);
        }
        else
        {
            isBoosted = false;
        }
       

    }
}
