using UnityEngine;
//https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Transform.Rotate.html
public class RotateMenuObject : MonoBehaviour {
    [SerializeField] private float rotationSpeed = -30f;
    public Transform startPosition;
    public static Transform shipPosition;
    public static float xRotation = 0;
    public static float yRotation = 0;
    public static float zRotation = 0;

    void Start() { //ship starts at a certain angle
        transform.eulerAngles = new Vector3(xRotation + 270,yRotation,zRotation);
    }

    void Update() {

        xRotation = transform.localRotation.x;
        yRotation = transform.localRotation.y;
        zRotation = transform.localRotation.z;
        transform.Rotate(0f, 0f, (-rotationSpeed * Time.deltaTime));
    }
}