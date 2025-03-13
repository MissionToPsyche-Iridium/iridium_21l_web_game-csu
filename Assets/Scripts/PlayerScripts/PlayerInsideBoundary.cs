using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class PlayerInsideBoundary : MonoBehaviour
{
    private bool startTime = false;
    private float waitTime = 10.2f;
    private float timer = 0f;
    private int skipFirstCheck = 0;
    float timeLeft;
    public TMP_Text OutOfBoundsWarning;
    public TMP_Text OutOfBoundsTime;
    // Update is called once per frame
    void Update()
    {
        if (!startTime)
        {
            OutOfBoundsWarning.color = Color.clear;
            OutOfBoundsTime.color = Color.clear;
            timer = 0f;
        }
        else
        {
            OutOfBoundsTime.color = Color.white;
            OutOfBoundsWarning.color = Color.white;
            startTimer();

            timeLeft = waitTime - timer; 
            if (timeLeft < 0) timeLeft = 0; //prevents negative values from showing on screen

            float minutes = Mathf.FloorToInt(timeLeft / 60f);
            float seconds = Mathf.FloorToInt(timeLeft % 60f);
            OutOfBoundsTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
    private void startTimer()
    {       
        timer += Time.deltaTime;
        Debug.Log(timer);
        if (timer >= waitTime)
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
