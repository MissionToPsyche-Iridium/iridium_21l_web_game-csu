using UnityEngine;

public class EmptyFollowPlayer : MonoBehaviour
{
    //initialize vars
    private Vector3 playerRot;
    private Transform playerT;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //set var equal to player object transform
        playerT = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //set current position to player, if not in cutscene also set rotation of current objects to the players.
        transform.position = playerT.position;
        if (!spawnScript.cutscene)
        {
            playerRot = playerT.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(new Vector3(playerRot.x, playerRot.y, transform.rotation.z));
        }
    }
}
