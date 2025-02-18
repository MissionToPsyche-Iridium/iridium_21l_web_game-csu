using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInsideBoundary : MonoBehaviour
{
    private bool startTime = false;
    private float waitTime = 10.0f;
    private float timer = 0.0f;
    private int skipFirstCheck = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startTime)
        {
            startTimer();
        }

    }
    
    private void startTimer()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);
        if (timer > waitTime)
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene(5);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Leaving! Please return to play area!");
        startTime = true;

    }
    private void OnTriggerEnter(Collider other)
    {
        timer = 0.0f;
        startTime = false;
        if (skipFirstCheck !=0)
        {
            Debug.Log("Back in playspace");
            
        }
        skipFirstCheck++;
    }
}
