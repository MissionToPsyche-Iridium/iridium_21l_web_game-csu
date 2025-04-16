using UnityEngine;
using UnityEngine.UIElements;

public class SpawnPaths : MonoBehaviour
{
    public GameObject path;
    private Transform pathEndPos;
    public int counter = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("PathEnd") && counter == 0)
        {
            
            Instantiate(path, new Vector3(transform.position.x, transform.position.y, transform.position.z + 90.35f), transform.rotation);
            counter += 1;


        }
    }
}
