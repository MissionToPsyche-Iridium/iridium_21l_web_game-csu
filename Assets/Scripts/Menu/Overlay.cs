using TMPro; 
using UnityEngine;
//this script displays the numbers overlay on the console in game
public class Overlay : MonoBehaviour {
    private float TimeElapsed = 0f; //declare timeelapsed
    public TMP_Text timerText; //timer in-game text
    public TMP_Text distanceText; //distance in-game text
    public TMP_Text speedometerText; //speed in-game text
    public static float minutes;
    public static float seconds;
    public void Update() {
        //Timer
        TimeElapsed += Time.deltaTime; // set time elapsed equal to built-in Time.deltaTime
        minutes = Mathf.FloorToInt(TimeElapsed / 60f); //minutes is time elapsed divided by 60
        seconds = Mathf.FloorToInt(TimeElapsed % 60f); //second is time elapsed mod 60

        if (spawnScript.cutscene == true) {
            timerText.color = new Color(1,1,1,0); // numbers are transparent when cutscene is ongoing
            distanceText.color = new Color(1,1,1,0);
            speedometerText.color = new Color(1,1,1,0);
            TimeElapsed = 0f; //start timeElapsed at 0 so that the cutscene doesn't add 5 seconds to overall time
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else if (spawnScript.cutscene == false) {
            timerText.color = new Color(1,1,1,1); // numbers are visible when cutscene is over
            distanceText.color = new Color(1,1,1,1);
            speedometerText.color = new Color(1,1,1,1);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        //Distance
        float currentDistance = (DistanceToEnd.distance * 150); //distance from player to end goal
        distanceText.text = string.Format("{0:F0} km", (currentDistance - 10));

        //Speedometer
        float currentSpeed = (MoveShip.shipVariableSpeed * 150); //speed player is currently moving at
        speedometerText.text = string.Format("{0:F1} km/s", currentSpeed);
    }
}

