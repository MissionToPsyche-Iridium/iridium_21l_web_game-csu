using UnityEngine;
using UnityEngine.InputSystem;
public class MoveShip : MonoBehaviour
{
    public GameObject shipCenter;
    public InputAction moveF;
    public InputAction moveB;
    //Created moveSpace input action
    public InputAction moveSpace;
    private float shipSpeed = 0.0f;
    public Rigidbody shipBody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveF = InputSystem.actions.FindAction("MoveF");
        moveB = InputSystem.actions.FindAction("MoveB");
        moveSpace = InputSystem.actions.FindAction("MoveSpace");
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void FixedUpdate()
    {
        if (moveF.IsPressed())
        {
            shipSpeed += .08f;
            shipSpeed = Mathf.Clamp(shipSpeed, -1.5f, 1.5f);
            shipBody.AddForce(transform.forward * shipSpeed);
        }
        if (moveB.IsPressed())
        {
            shipSpeed -= .08f;
            shipSpeed = Mathf.Clamp(shipSpeed, -1.5f, 1.5f);
            shipBody.AddForce(transform.forward * shipSpeed);
        }
        //Created new bit so it boosts whenever keys F and space-bar are both pressed at same time
        if (moveSpace.IsPressed())
        {
            shipSpeed += 100000.0f;
            shipSpeed = Mathf.Clamp(shipSpeed, -1.5f, 1.5f);
            shipBody.AddForce(transform.forward * shipSpeed);
        }
    }
}
