using UnityEngine;

public class RotateAroundPsyche : MonoBehaviour
{
    //initialize vars
    public GameObject psycheCenter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        //rotate around object that is Psyche center at set speed.
        transform.RotateAround(psycheCenter.transform.position, Vector3.up, 20 * Time.deltaTime);
    }
}
