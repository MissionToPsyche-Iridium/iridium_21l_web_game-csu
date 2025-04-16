using TMPro;
using Unity.VisualScripting;
using UnityEngine;
public class WinScreenTime: MonoBehaviour {
    private float TimeElapsed = 0f;
    public TMP_Text TimeTakenText;
    float minutesTaken = Overlay.minutes;
    float secondsTaken = Overlay.seconds;
    void Update() {
        if (DistanceToEnd.gameWon == true) {
            TimeTakenText.text = string.Format("Time Taken: {0:00}:{1:00}", minutesTaken, secondsTaken);
        }
        else 
            TimeTakenText.text = ""; //are you sure
    }
}

