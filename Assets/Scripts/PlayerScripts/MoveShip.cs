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
    public static bool isSlingshot = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isSlingshot = false;
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
        if (spawnScript.cutscene)
        {
            shipBody.linearVelocity = new Vector3(0f, 0f);
            moveW.Disable();
            moveS.Disable();
            moveA.Disable();   
            moveD.Disable();    
            moveShift.Disable();    
            moveSpace.Disable();    
            moveCtrl.Disable();
        }
        else
        {
            moveW.Enable(); 
            moveS.Enable(); 
            moveA.Enable(); 
            moveD.Enable();
            moveShift.Enable(); 
            moveSpace.Enable();
            moveCtrl.Enable();
        }
        
        //https://www.youtube.com/watch?v=7NMsVub5NZM
        //Debug.Log(shipBody.linearVelocity.magnitude);
        //Debug.Log(shipSpeed);
        if (!isBoosted && !isSlingshot) 
        { 
            //5
            shipBody.linearVelocity = Vector3.ClampMagnitude(shipBody.linearVelocity, 5f); 
        }
        else if (isBoosted && !isSlingshot)
        {
            //9
            shipBody.linearVelocity = Vector3.ClampMagnitude(shipBody.linearVelocity, 9f);
        }
        else if (!isBoosted && isSlingshot)
        {
            shipBody.AddForce(Vector3.forward * shipSpeed);
            shipBody.linearVelocity = Vector3.ClampMagnitude(shipBody.linearVelocity, 20f);
           
        }
        else if (isBoosted && isSlingshot)
        {
            shipBody.AddForce(Vector3.forward* shipSpeed);
            shipBody.linearVelocity = Vector3.ClampMagnitude(shipBody.linearVelocity, 24f);
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
        }
        else
        {
            isBoosted = false;
        }


    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Slingshot")){
            isSlingshot = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Slingshot"))
        {
            isSlingshot = false;
        }
    }
}
