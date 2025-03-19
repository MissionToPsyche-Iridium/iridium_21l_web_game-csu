using UnityEngine;
//https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Transform.Rotate.html
public class RotateMenuObject : MonoBehaviour {
    [SerializeField] private float rotationSpeed = 30f;
    private float savedRotation;

    void Start() {
        savedRotation = PlayerPrefs.GetFloat("MenuRotation", 0);
        transform.rotation = Quaternion.Euler(0, 0, savedRotation);
    }
    void Update() {
        transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime);
        PlayerPrefs.SetFloat("MenuRotation", transform.eulerAngles.z);
    }
}