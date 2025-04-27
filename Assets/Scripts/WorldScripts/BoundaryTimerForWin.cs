using UnityEngine;

public class BoundaryTimerForWin : MonoBehaviour
{
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
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Stay in area until ship is maintained at safe distance.");
            timer += Time.deltaTime;

            if (timer > waitTime)
            {
                playerWon = true;
                Debug.Log("You Win!");
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
