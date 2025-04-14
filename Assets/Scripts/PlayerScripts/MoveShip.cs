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

    private bool isCoroutineRunning = false;
    public static float boost_value = 100;  // Starting boost value
    private bool canRecharge = true;
    private float boostCooldownTime = 5f;  // Cooldown time after boost depletes
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
        moveW.Disable();
        moveS.Disable();
        moveA.Disable();
        moveD.Disable();
        moveShift.Disable();
        moveSpace.Disable();
        moveCtrl.Disable();
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
            shipBody.linearVelocity = Vector3.ClampMagnitude(shipBody.linearVelocity, 7f); // normal movement speed = 7
        }
        else if (isBoosted && !isSlingshot)
        {
            shipBody.linearVelocity = Vector3.ClampMagnitude(shipBody.linearVelocity, 15f); //boost movement speed = 15
        }
        else if (!isBoosted && isSlingshot)
        {
            shipBody.AddForce(Vector3.forward * shipSpeed);
            shipBody.linearVelocity = Vector3.ClampMagnitude(shipBody.linearVelocity, 30f); //slingshot movement speed = 30
           
        }
        else if (isBoosted && isSlingshot)
        {
            shipBody.AddForce(Vector3.forward* shipSpeed);
            shipBody.linearVelocity = Vector3.ClampMagnitude(shipBody.linearVelocity, 30f); //slingshot movement speed while boosted still = 30
        }


        shipVariableSpeed = shipBody.linearVelocity.magnitude;
    }
    void FixedUpdate()
    {
        Debug.Log(boost_value);
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
            boost_value = Mathf.Clamp(boost_value - 1f, 0f, 100f);
        }
        else
        {
            isBoosted = false;
            if (canRecharge)
            {
                boost_value = Mathf.Clamp(boost_value + 1f, 0f, 100f);
            }
        }
          if (boost_value < 1f)
        {
            moveShift.Disable();
            moveShift.Enable();
            canRecharge = false;
            if (!isCoroutineRunning)
            {
                StartCoroutine(BoostRecharge());
            }
            
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
    IEnumerator BoostRecharge()
    {
        isCoroutineRunning = true;
        yield return new WaitForSeconds(3f);
        canRecharge = true;
        isCoroutineRunning = false;
    }
}
