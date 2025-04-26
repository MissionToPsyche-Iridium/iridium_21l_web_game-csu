using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
public class MoveShip : MonoBehaviour
{
    //initialize vars
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
    private bool didSlingshotSoundPlay = false;
    private Coroutine restartCoroutine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //set vars equal and make sure they're disabled on loadup to prevent bugs during cutscene.
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
        //if cutscene is playing, disable all movement, if not enable all movement
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
        //if left shift or boost was released, start timer for boost regen
        if (moveShift.WasReleasedThisFrame() && boost_value >= 1f)
        {
            isBoosted = false;
            if (restartCoroutine != null)
            {
                StopCoroutine(restartCoroutine);
                isCoroutineRunning = false;
            }
            if (!isCoroutineRunning)
            {

                restartCoroutine = StartCoroutine(BoostRecharge());

            }

        }
        //if boost is empty, start timer for boost regen.
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
        //these helped in the process of creating and limiting the ships movement, but each if statement sets the speed of the ship for different player inputs.
        //https://www.youtube.com/watch?v=7NMsVub5NZM
        //https://docs.unity3d.com/6000.0/Documentation/ScriptReference/BoxCollider.html
        if (!isBoosted && !isSlingshot) // numbers are rounded oddly to make UI look better (for example: 1000/150 = 6.66667, in which 150 = km * in-game distance to Psyche)
        { 
            shipCenter.GetComponent<BoxCollider>().enabled = true;
            shipBody.linearVelocity = Vector3.ClampMagnitude(shipBody.linearVelocity, 6.66667f); // normal movement speed = 6.66667
        }
        else if (isBoosted && !isSlingshot)
        {
            shipCenter.GetComponent<BoxCollider>().enabled = true;
            shipBody.linearVelocity = Vector3.ClampMagnitude(shipBody.linearVelocity, 16.66667f); //boost movement speed = 16.66667
        }
        else if (!isBoosted && isSlingshot)
        {
            shipCenter.GetComponent<BoxCollider>().enabled = false;
            shipBody.AddForce(Vector3.forward * shipSpeed);
            shipBody.linearVelocity = Vector3.ClampMagnitude(shipBody.linearVelocity, 33.33333f); //slingshot movement speed = 33.33333
           
        }
        else if (isBoosted && isSlingshot)
        {
            shipCenter.GetComponent<BoxCollider>().enabled = false;
            shipBody.AddForce(Vector3.forward* shipSpeed);
            shipBody.linearVelocity = Vector3.ClampMagnitude(shipBody.linearVelocity, 33.33333f); //slingshot movement speed while boosted still = 33.33333
        }
        shipVariableSpeed = shipBody.linearVelocity.magnitude;
    }
    void FixedUpdate()
    {   
        //sets directions of the movement for each input.
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
        //check if w and left shift is pressed, if true then player is boosting and decrease value
        if (moveW.IsPressed() && moveShift.IsPressed())
        {
            canRecharge = false;
            isBoosted = true;
            boost_value = Mathf.Clamp(boost_value - 1f, 0f, 100f);
        }
        //if boost can recharge, add to boost value
        if (canRecharge)
        {
            boost_value = Mathf.Clamp(boost_value + 1f, 0f, 100f);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //if object enters slingshot, then play sound
        if (other.CompareTag("Slingshot")){
            GameAudio.PlaySlingshotSound();
            didSlingshotSoundPlay = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {   
        //if object is in the slingshot, set bool to true
        if (other.CompareTag("Slingshot")){
            isSlingshot = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //if object isn't in the slingshot, set bool to false
        if (other.CompareTag("Slingshot"))
        {
            isSlingshot = false;
        }
    }
    //coroutine for recharging boost, waits 3 seconds then allows for recharge again.
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