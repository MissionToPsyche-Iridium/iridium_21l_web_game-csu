using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class PlayerInsideBoundary : MonoBehaviour
{
    //initialize vars
    private bool startTime = false;
    private float waitTime = 10.2f;
    private float timer = 0f;
    float timeLeft;
    public TMP_Text OutOfBoundsWarning;
    public TMP_Text OutOfBoundsTime;
    // Update is called once per frame
    void Update()
    {
        //if cutscene is true and starttime is false, make sure no message is shown and set time to 0
        if (!startTime && spawnScript.cutscene == true)
        {

            OutOfBoundsWarning.color = Color.clear;
            OutOfBoundsTime.color = Color.clear;
            timer = 0f;
        }
        //if out of cutscene and starttime is true, show out of bounds timer
        else if (startTime && spawnScript.cutscene == false)
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
        //if starttime is false and not in cutscene, clear out of bounds text
        else if (!startTime && spawnScript.cutscene == false)
        {
            OutOfBoundsWarning.color = Color.clear;
            OutOfBoundsTime.color = Color.clear;
            timer = 0f;
        }
    }
    //method to count time, and if time is greater than 10 seconds, load you lose scene.
    private void startTimer()
    {
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            SceneManager.LoadScene(5);
        }
    }
    //while object is in boundary, dont start timer
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PlayerBoundary"))
        {
            startTime = false;
            timer = 0.0f;
        }
        
    }
    //when player exits bounds, start the timer
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerBoundary"))
        {
            startTime = true;
        }
    }
}
