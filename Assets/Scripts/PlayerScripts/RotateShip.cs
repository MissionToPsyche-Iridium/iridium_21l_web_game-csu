using UnityEngine;

public class RotateShip : MonoBehaviour
{   //declare variables
    public Vector2 turn;
    public GameObject shipCenter;
    private float rotateZ = 0f;
    public static bool flipY = false; //Dylan
    public static float sensitivity = 1f; //Dylan 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = shipCenter.transform.localEulerAngles;
        //establish mouse input variables, and match horizontal mouse movement with ship's Z rotation
        turn.x += Input.GetAxis("Mouse X") * (2*sensitivity);
        //rotateZ += Input.GetAxis("Mouse X");
        if (RotateShip.flipY == false) {
            turn.y -= Input.GetAxis("Mouse Y") * (2*sensitivity);
        }
        else if (RotateShip.flipY == true) {
            turn.y += Input.GetAxis("Mouse Y") * (2*sensitivity);
        }
        //clamp z rotation on ship
        rotateZ = Mathf.Clamp(rotateZ, -40f, 40f);

        //rotate the ship
        shipCenter.transform.rotation = Quaternion.Euler(turn.y, turn.x, -rotateZ);
        
    }
}
