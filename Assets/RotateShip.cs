using UnityEngine;

public class RotateShip : MonoBehaviour
{
    public Vector2 turn;
    public GameObject shipCenter;
    private float shipRotate = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 rotation = shipCenter.transform.localEulerAngles;
        turn.x = Input.GetAxis("Mouse X");
        turn.y = Input.GetAxis("Mouse Y");
        //rotation.z += Mathf.Clamp(rotation.z, -20.0f, 20.0f);
       /* if (shipCenter.transform.rotation.z < 0)
        {
            shipRotate = shipCenter.transform.rotation.eulerAngles.z;
            shipRotate = Mathf.Clamp(shipRotate, 340.0f, 360.0f);
        }
        else
        {
            shipRotate = shipCenter.transform.rotation.eulerAngles.z;
            shipRotate = Mathf.Clamp(shipRotate, 0.0f, 20.0f);
        }
       */
        shipCenter.transform.Rotate(turn.y, turn.x, 0.0f);
        //Mathf.Clamp(shipCenter.transform.rotation.eulerAngles.z, 20.0f, 340.0f);
       /* Debug.Log(shipCenter.transform.rotation.z);
        Debug.Log(shipCenter.transform.rotation.eulerAngles.z);
        Debug.Log("custom" + shipRotate);
       */
    }
}
