using UnityEngine;

public class EmptyFollowPlayer : MonoBehaviour
{
    private Transform playerT;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerT = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerT.position;
    }
}
