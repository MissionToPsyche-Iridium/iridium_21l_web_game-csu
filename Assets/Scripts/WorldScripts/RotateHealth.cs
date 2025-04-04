using UnityEngine;

public class RotateHealth : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float rotateSpeed = 10f;
    void Start()
    {

    }

    private void Update()
    {
       
        transform.GetChild(0).Rotate(0f, rotateSpeed * Time.deltaTime, 0f);
        

    }

}
