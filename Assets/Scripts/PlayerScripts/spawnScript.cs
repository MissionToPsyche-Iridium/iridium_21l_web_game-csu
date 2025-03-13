using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class spawnScript : MonoBehaviour
{
    public GameObject positionOne;
    public GameObject positionTwo;
    public GameObject positionCam;
    private Transform posT1;
    private Transform posT2;
    private Transform posCam;
    public Rigidbody lockedRotateRB;
    private bool pos1Done = false;
    private float waitTime = 2f;
    private float timer = 0.0f;
    public static float cutsceneTime = 5.3f;
    public static bool cutscene = true;
    private bool timerOn = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posT1 = positionOne.transform;
        posT2 = positionTwo.transform;
        posCam = positionCam.transform;
        cutscene = true;
        timerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (timerOn) 
        {
            timer += Time.deltaTime;
        }
        var step = 10f * Time.deltaTime;
        var camStep = 14f * Time.deltaTime;
        if (timer > 0 && timer < 3.3f && tag == "ship") 
        {
            transform.position = Vector3.MoveTowards(transform.position, posT1.position, step);
            transform.rotation = Quaternion.Slerp(transform.rotation, lockedRotateRB.rotation, 1.5f * Time.deltaTime);

        }
        if (timer > 3f && timer < cutsceneTime && tag == "ship")
        {
            transform.position = Vector3.MoveTowards(transform.position, posT2.position, step);
            transform.rotation = Quaternion.Slerp(transform.rotation, lockedRotateRB.rotation, 1.5f * Time.deltaTime);
        }
        if (timer > 2f && timer < cutsceneTime && tag == "MainCamera")
        {
            transform.position = Vector3.MoveTowards(transform.position, posCam.position, camStep);
        }
        
        if (timer > cutsceneTime)
        {
            cutscene = false;
            timerOn = false;
        }

    }

}
