using UnityEngine;

public class RotateHealth : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //initialize vars
    public float rotateSpeed = 10f;
    void Start()
    {

    }

    private void Update()
    {
        //get child which is center of the heart so it rotates properly, and rotate at set speed.
        transform.GetChild(0).Rotate(0f, rotateSpeed * Time.deltaTime, 0f);
        

    }

}
