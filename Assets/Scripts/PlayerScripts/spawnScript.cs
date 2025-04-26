using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class spawnScript : MonoBehaviour
{
    //initialize vars
    public GameObject positionOne;
    public GameObject positionTwo;
    public GameObject positionCam;
    private Transform posT1;
    private Transform posT2;
    private Transform posCam;
    public Rigidbody lockedRotateRB;
    private float timer = 0.0f;
    public static float cutsceneTime = 5.3f;
    public static bool cutscene = true;
    private bool timerOn = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //set vars equal to object positions
        posT1 = positionOne.transform;
        posT2 = positionTwo.transform;
        posCam = positionCam.transform;
        cutscene = true;
        timerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
       //activate timer if bool is true
        if (timerOn) 
        {
            timer += Time.deltaTime;
        }
        //find out how fast to "lerp" the camera to positions
        var step = 10f * Time.deltaTime;
        var camStep = 14f * Time.deltaTime;
        //for first 3 seconds, ship to first point and rotate
        if (timer > 0 && timer < 3.3f && tag == "ship") 
        {
            transform.position = Vector3.MoveTowards(transform.position, posT1.position, step);
            transform.rotation = Quaternion.Slerp(transform.rotation, lockedRotateRB.rotation, 1.5f * Time.deltaTime);

        }
        //for after 3 seconds, ship to second point and rotate
        if (timer > 3f && timer < cutsceneTime && tag == "ship")
        {
            transform.position = Vector3.MoveTowards(transform.position, posT2.position, step);
            transform.rotation = Quaternion.Slerp(transform.rotation, lockedRotateRB.rotation, 1.5f * Time.deltaTime);
        }
        //after 2 seconds, move cam to position
        if (timer > 2f && timer < cutsceneTime && tag == "MainCamera")
        {
            transform.position = Vector3.MoveTowards(transform.position, posCam.position, camStep);
        }
        //once timer is up, stop the cutscene
        if (timer > cutsceneTime)
        {
            cutscene = false;
            timerOn = false;
        }

    }

}
