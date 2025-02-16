using UnityEngine;
//https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Transform.Rotate.html
public class RotateMenuObject : MonoBehaviour {
    [SerializeField] private float rotationSpeed = 30f;

    void Update() {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}