using JetBrains.Annotations;
using TMPro; 
using UnityEngine;
using UnityEngine.UI;
public class Overlay : MonoBehaviour {
    private float TimeElapsed = 0f;
    public TMP_Text timerText;
    public TMP_Text distanceText;
    public TMP_Text speedometerText;
    void Update() {
        //Timer
        TimeElapsed += Time.deltaTime;
        float minutes = Mathf.FloorToInt(TimeElapsed / 60f);
        float seconds = Mathf.FloorToInt(TimeElapsed % 60f);

        if (spawnScript.cutscene == true) {
            TimeElapsed = 0f;
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else if (spawnScript.cutscene == false) {
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
