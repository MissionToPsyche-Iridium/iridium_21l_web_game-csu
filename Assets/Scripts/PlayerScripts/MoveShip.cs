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
    public InputAction moveShiftRelease;
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
    private Coroutine restartCoroutine;
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

        if (moveShift.WasReleasedThisFrame() && boost_value >= 1f)
        {
            isBoosted = false;
            if (restartCoroutine != null)
            {
                StopCoroutine(restartCoroutine);
                isCoroutineRunning = false;
                Debug.Log("Stop Coroutine");
            }
            if (!isCoroutineRunning)
            {

                restartCoroutine = StartCoroutine(BoostRecharge());

            }

        }

        if (boost_value < 1f)
        {
            moveShift.Disable();
            moveShift.Enable();
            isBoosted = false;
            if (!isCoroutineRunning)
            {
                StartCoroutine(BoostRecharge());
            }

        }

        //https://www.youtube.com/watch?v=7NMsVub5NZM
        //Debug.Log(shipBody.linearVelocity.magnitude);
        //Debug.Log(shipSpeed);
        if (!isBoosted && !isSlingshot) // numbers are rounded oddly to make UI look better (for example: 1000/150 = 6.66667, in which 150 = km * in-game distance to Psyche)
        { 
            shipBody.linearVelocity = Vector3.ClampMagnitude(shipBody.linearVelocity, 6.66667f); // normal movement speed = 6.66667
        }
        else if (isBoosted && !isSlingshot)
        {
            shipBody.linearVelocity = Vector3.ClampMagnitude(shipBody.linearVelocity, 16.66667f); //boost movement speed = 16.66667
        }
        else if (!isBoosted && isSlingshot)
        {
            shipBody.AddForce(Vector3.forward * shipSpeed);
            shipBody.linearVelocity = Vector3.ClampMagnitude(shipBody.linearVelocity, 33.33333f); //slingshot movement speed = 33.33333
           
        }
        else if (isBoosted && isSlingshot)
        {
            shipBody.AddForce(Vector3.forward* shipSpeed);
            shipBody.linearVelocity = Vector3.ClampMagnitude(shipBody.linearVelocity, 33.33333f); //slingshot movement speed while boosted still = 33.33333
        }


        shipVariableSpeed = shipBody.linearVelocity.magnitude;
    }
    void FixedUpdate()
    {
        //Debug.Log(boost_value);
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
            canRecharge = false;
            isBoosted = true;
            boost_value = Mathf.Clamp(boost_value - 1f, 0f, 100f);
        }

        if (canRecharge)
        {
            boost_value = Mathf.Clamp(boost_value + 1f, 0f, 100f);
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
        canRecharge = false;
        yield return new WaitForSeconds(3f);
        boost_value += 1f;
        canRecharge = true;
        isCoroutineRunning = false;
    }
}