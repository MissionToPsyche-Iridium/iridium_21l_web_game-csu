using System.Collections;
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

    private float boost_value = 200;  // Starting boost value
    private bool isBoostAvailable = true;
    private bool isDepleting = false;

    private float boostCooldownTime = 5f;  // Cooldown time after boost depletes
    private float countdownTimer = 5f;

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
            shipBody.linearVelocity = Vector3.ClampMagnitude(shipBody.linearVelocity, 5f); 
        }
        else if (isBoosted && !isSlingshot && isBoostAvailable)
        {
            shipBody.linearVelocity = Vector3.ClampMagnitude(shipBody.linearVelocity, 9f);
        }
        else if (!isBoosted && isSlingshot)
        {
            shipBody.AddForce(Vector3.forward * shipSpeed);
            shipBody.linearVelocity = Vector3.ClampMagnitude(shipBody.linearVelocity, 20f);
           
        }
        else if (isBoosted && isSlingshot && isBoostAvailable)
        {
            shipBody.AddForce(Vector3.forward* shipSpeed);
            shipBody.linearVelocity = Vector3.ClampMagnitude(shipBody.linearVelocity, 24f);
        }
        else
        {
            shipBody.linearVelocity = Vector3.ClampMagnitude(shipBody.linearVelocity, 5f);
        }


        shipVariableSpeed = shipBody.linearVelocity.magnitude;
       // Debug.Log("Boost value " + boost_value);
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
            if (isBoostAvailable)
            {
                isBoosted = true;
                boost_value = Mathf.Clamp(boost_value -= 1.5f, 0f, 200f);
                if (boost_value < .1f)
                {
                    StartCoroutine(DepleteBoostValue());
                }

            }
            
        }
        else
        {
            
            if (isBoostAvailable)
            {

                boost_value = Mathf.Clamp(boost_value += .5f, 0f, 200f);
                
            }
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
    
    IEnumerator DepleteBoostValue()
    {

        isBoostAvailable = false;  // Disable boost availability
        Debug.Log("Boost depleted! Starting cooldown...");
        yield return new WaitForSeconds(boostCooldownTime);  // Wait for the cooldown to finish

        // After cooldown, regenerate boost value
        
        isBoostAvailable = true;  // Boost is available again;
        Debug.Log("Boost available again!");


    }
}
