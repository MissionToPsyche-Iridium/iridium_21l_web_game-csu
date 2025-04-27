using UnityEngine;

public class followPlayerZ : MonoBehaviour
{
    private GameObject playerShip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerShip = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerShip.transform.position.x + 690f, transform.position.y, playerShip.transform.position.z-100.0f);
    }
}
