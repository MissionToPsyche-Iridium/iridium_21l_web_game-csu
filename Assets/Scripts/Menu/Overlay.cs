using JetBrains.Annotations;
using TMPro; 
using UnityEngine;
using UnityEngine.UI;
public class Overlay : MonoBehaviour {
    private float TimeElapsed = 0f;
    public static float delayTimer = spawnScript.cutsceneTime;
    public TMP_Text timerText;
    public TMP_Text distanceText;
    public TMP_Text speedometerText;
    void Update() {
        //Timer
        TimeElapsed += Time.deltaTime;
        float minutes = Mathf.FloorToInt(TimeElapsed / 60f);
        float seconds = (Mathf.FloorToInt(TimeElapsed % 60f) - delayTimer);

        if (seconds < 0) {
            timerText.text = string.Format("{0:00}:{1:00}", 0, 0);
        }
        else {
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        //Distance
        float currentDistance = DistanceToEnd.distance;
        distanceText.text = string.Format("{0:F0} m", (currentDistance - 10));

        //Speedometer
        float currentSpeed = MoveShip.shipVariableSpeed;
        speedometerText.text = string.Format("{0:F1} m/s", currentSpeed);
    }
}
