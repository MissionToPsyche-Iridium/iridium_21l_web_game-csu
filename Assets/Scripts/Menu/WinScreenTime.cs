using TMPro;
using Unity.VisualScripting;
using UnityEngine;
public class WinScreenTime: MonoBehaviour {
    public TMP_Text TimeTakenText;
    float minutesTaken = Overlay.minutes; //minutes taken from overlay
    float secondsTaken = Overlay.seconds; //seconds taken from overlay
    void Update() {
        if (DistanceToEnd.gameWon == true) {
            TimeTakenText.text = string.Format("Time Taken: {0:00}:{1:00}", minutesTaken, secondsTaken); //time elapsed shown on winning screen, should be around 6 mins
        }
        else 
            TimeTakenText.text = ""; //are you sure
    }
}

