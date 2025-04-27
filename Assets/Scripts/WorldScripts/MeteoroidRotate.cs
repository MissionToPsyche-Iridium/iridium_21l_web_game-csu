using UnityEngine;

public class MeteoroidRotate : MonoBehaviour
{
    //initialize vars
    private float ranSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //pick random speed from between floats
        ranSpeed = Random.Range(0.1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        //constantly rotate using the randomly generated speed
        transform.Rotate(ranSpeed, ranSpeed, ranSpeed);
    }
}
