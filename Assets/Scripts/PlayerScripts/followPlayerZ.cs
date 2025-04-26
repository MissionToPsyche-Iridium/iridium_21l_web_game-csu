using UnityEngine;

public class followPlayerZ : MonoBehaviour
{
    //initialize vars
    private GameObject playerShip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //set var equal to player object
        playerShip = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {  
        //set position of the object that this script is attached to, to the players plus/minus an offset. Used for the sun.
        transform.position = new Vector3(playerShip.transform.position.x + 690f, transform.position.y, playerShip.transform.position.z-100.0f);
    }
}
