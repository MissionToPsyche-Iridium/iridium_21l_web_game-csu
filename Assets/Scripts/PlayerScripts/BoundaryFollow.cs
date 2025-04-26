using JetBrains.Annotations;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class BoundaryFollow : MonoBehaviour
{
    //initialize vars
    private Vector3 playerRot;
    public GameObject centerShip;
    private float localPlayerX;
    private float localPlayerY;
    private Transform centerShipTransform;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //set the var equal to the player ship transform
        centerShipTransform = centerShip.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //set local floats equal to x and y of player position, and rotation, then set the transform of current object to those values.
        localPlayerX = centerShip.transform.position.x;
        localPlayerY = centerShip.transform.position.y;
        playerRot = centerShipTransform.rotation.eulerAngles;
        transform.position = new Vector3(localPlayerX, localPlayerY, centerShip.transform.position.z);
        transform.rotation = Quaternion.Euler(new Vector3(playerRot.x, playerRot.y, playerRot.z));
    }
}
