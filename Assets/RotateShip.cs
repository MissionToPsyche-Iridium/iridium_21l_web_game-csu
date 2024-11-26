using UnityEngine;

public class RotateShip : MonoBehaviour
{   //declare variables
    public Vector2 turn;
    public GameObject shipCenter;
    private float shipRotate = 0f;
    private float rotateZ = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = shipCenter.transform.localEulerAngles;
        //establish mouse input variables, and match horizontal mouse movement with ship's Z rotation
        turn.x += Input.GetAxis("Mouse X");
        rotateZ += Input.GetAxis("Mouse X");
        turn.y += Input.GetAxis("Mouse Y");
        //clamp z rotation on ship
        rotateZ = Mathf.Clamp(rotateZ, -40f, 40f);

        //rotate the ship
        shipCenter.transform.rotation = Quaternion.Euler(turn.y, turn.x, -rotateZ);
        
    }
}
