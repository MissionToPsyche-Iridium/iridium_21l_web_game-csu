using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInsideBoundary : MonoBehaviour
{
    private bool startTime = true;
    private float waitTime = 10.0f;
    private float timer = 0.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startTime && spawnScript.cutscene==false)
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
    private void OnTriggerStay(Collider other)
    {
        startTime = false;
        timer = 0.0f;
    }

    private void OnTriggerExit(Collider other)
    {
        startTime = true;
    }
}
