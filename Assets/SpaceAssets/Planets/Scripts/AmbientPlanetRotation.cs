using UnityEngine;

public class AmbientPlanetRotatie : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Rotate(0f, .1f, 0f);
    }


}
