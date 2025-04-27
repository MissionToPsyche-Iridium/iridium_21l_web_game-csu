using UnityEngine;

public class MeteoroidRotate : MonoBehaviour
{
    private float ranSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ranSpeed = Random.Range(0.1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        transform.Rotate(ranSpeed, ranSpeed, ranSpeed);
    }
}
