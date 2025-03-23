using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveShip : MonoBehaviour
{
    public GameObject shipCenter;
    public InputAction moveW;
    public InputAction moveS;
    public InputAction moveA;
    public InputAction moveD;
    public InputAction moveShift;
    public InputAction moveSpace;
    public InputAction moveCtrl;
    public Rigidbody shipBody;
    public static float shipSpeed = 5;
    public static float shipVariableSpeed = 0f;

    private bool isBoosted = false;
    private int boost_value = 200;  // Starting boost value
    private bool isBoostAvailable = true;
    private bool isDepleting = false;

    private float boostCooldownTime = 5f;  // Cooldown time after boost depletes
    private float countdownTimer = 5f;

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

    void Update()
    {
        // Disable/Enable input based on the cutscene flag
        if (spawnScript.cutscene)
        {
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

        // Handle boost depletion and regeneration
        if (isBoosted)
        {
            StartCoroutine(DepleteBoostValue());
        }

        // Print countdown timer in the console
        if (countdownTimer >= 0f)
        {
            countdownTimer -= Time.deltaTime;
            Debug.Log("Boost cooldown: " + Mathf.Ceil(countdownTimer) + " seconds");
        }

        // Clamp ship velocity to prevent over-speed when not boosted
        if (!isBoosted)
        {
            shipBody.linearVelocity = Vector3.ClampMagnitude(shipBody.linearVelocity, 5f);
        }

        shipVariableSpeed = shipBody.linearVelocity.magnitude;
    }

    void FixedUpdate()
    {
        // Movement inputs for the ship
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

        // Boost logic: activated when both 'W' and 'Shift' are pressed
        if (moveW.IsPressed() && moveShift.IsPressed() && isBoostAvailable && boost_value > 0)
        {
            isBoosted = true;
            if (!isDepleting)
            {
                StartCoroutine(DepleteBoostValue());
            }
            
            shipSpeed += 1f;
            shipSpeed = Mathf.Clamp(shipSpeed, 0f, 10f);  // Limit boost speed
            shipBody.linearVelocity = Vector3.ClampMagnitude(shipBody.linearVelocity, 15f);  // Limit boost speed
        }
        else
        {
            isBoosted = false;
        }
    }

    IEnumerator DepleteBoostValue()
    {
        isDepleting = true;
        // Decrease boost_value by 1 every second while boosting is active
        while (boost_value > 0)
        {
            yield return new WaitForSeconds(1f);
            boost_value--;

            // When boost_value reaches zero, stop boosting and start cooldown
            if (boost_value <= 0)
            {
                isBoosted = false;  // Disable boost
                isBoostAvailable = false;  // Disable boost availability
                countdownTimer = boostCooldownTime;  // Set cooldown timer
                Debug.Log("Boost depleted! Starting cooldown...");
                yield return new WaitForSeconds(boostCooldownTime);  // Wait for the cooldown to finish

                // After cooldown, regenerate boost value
                boost_value = 10;  // Reset boost value
                isBoostAvailable = true;  // Boost is available again
                isDepleting = false;
                Debug.Log("Boost available again!");
            }
        }
    }
}

