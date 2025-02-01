using JetBrains.Annotations;
using UnityEngine;

public class BoundaryFollow : MonoBehaviour
{
    public GameObject centerShip;
    private float localPlayerX;
    private float localPlayerY;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        localPlayerX = centerShip.transform.position.x;
        localPlayerY = centerShip.transform.position.y; 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(localPlayerX, localPlayerY, centerShip.transform.position.z);
    }
}
