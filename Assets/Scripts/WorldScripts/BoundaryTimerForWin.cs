using UnityEngine;

public class BoundaryTimerForWin : MonoBehaviour
{
    //initialize vars
    public GameObject player;
    private float waitTime = 3f;
    private float timer = 0.0f;
    private bool playerWon = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        //if player in boundary start timer, once in for long enough player won equals true
        //this script is obselete in current game.
        if (other.gameObject.CompareTag("Player"))
        {
            timer += Time.deltaTime;

            if (timer > waitTime)
            {
                playerWon = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && playerWon == false)
        {
            timer = 0.0f;
        }
    }
}
