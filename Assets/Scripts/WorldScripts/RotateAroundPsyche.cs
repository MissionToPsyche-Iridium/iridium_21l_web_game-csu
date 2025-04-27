using UnityEngine;

public class RotateAroundPsyche : MonoBehaviour
{
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
        transform.RotateAround(psycheCenter.transform.position, Vector3.up, 20 * Time.deltaTime);
    }
}
