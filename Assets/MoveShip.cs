using UnityEngine;
using UnityEngine.InputSystem;
public class MoveShip : MonoBehaviour
{
    public GameObject shipCenter;
    public InputAction moveF;
    public InputAction moveB;
    private float shipSpeed = 0.0f;
    public Rigidbody shipBody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveF = InputSystem.actions.FindAction("MoveF");
        moveB = InputSystem.actions.FindAction("MoveB");
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
    }
}
