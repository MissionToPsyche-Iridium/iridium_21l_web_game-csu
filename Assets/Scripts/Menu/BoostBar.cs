using UnityEngine;
public class BoostBar : MonoBehaviour {
    public Vector3 normalScale; // size of bar when at 100%
    public Vector3 startingBarPosition; // initial position of bar (to account for offset of bar being to the left on the console)
    public float startingXValue = 0.2407f; // initial x value
    void Start() {
        normalScale = transform.localScale;
        startingBarPosition = new Vector3(startingXValue, transform.localPosition.y, transform.localPosition.z);
        transform.localPosition = startingBarPosition; // bar is put into position on game start
    }
    void Update() {
        float boostAmount = Mathf.Clamp01(MoveShip.boost_value / 100f); //boost ranges from 0 to 1 similar to the moveship method being from 0 to 100

        transform.localScale = new Vector3(normalScale.x * boostAmount, normalScale.y, normalScale.z); // bar shrinks horizontally only
        float xOffset = (normalScale.x * (boostAmount - 1f)) / 2f; // bar shrinks from right to left
        transform.localPosition = new Vector3(startingBarPosition.x + xOffset, transform.localPosition.y, transform.localPosition.z); //make sure side is anchored while scale shrinks
    }
}
