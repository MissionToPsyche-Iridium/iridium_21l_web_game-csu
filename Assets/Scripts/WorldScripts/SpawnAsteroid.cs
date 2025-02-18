using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnAsteroid : MonoBehaviour
{
    
    public GameObject asteroid;
    public Transform asteroidSpawnerTransform;
    private GameObject newAsteroid;
    private Rigidbody asteroidRB;
    //private bool canScale = false;
    private float waitTime = 0f;
    private float timer = 0.0f;
    private float ranX, ranY,ranSpeed = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        waitTime = Random.Range(3.0f, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer > waitTime)
        {
            timer -= waitTime;
            //ranX = Random.Range(-45f, 45f);
            //ranY = Random.Range(110f, 250f);
            ranX = Random.Range(-20f, 20f);
            ranY = Random.Range(170f, 190f);
            ranSpeed = Random.Range(3f, 15f);
            asteroidSpawnerTransform.rotation = Quaternion.Euler(ranX, ranY, 0f);
            spawnAsteroid();
            waitTime = Random.Range(3.0f, 10.0f);

        }

        
    }

    private void spawnAsteroid()
    {
        newAsteroid = Instantiate(asteroid, asteroidSpawnerTransform.position, asteroidSpawnerTransform.rotation);
        asteroidRB = newAsteroid.GetComponent<Rigidbody>();
        scaleAsteroid(asteroidRB, newAsteroid);
        
        asteroidRB.linearVelocity = asteroidRB.transform.TransformDirection(Vector3.forward * ranSpeed);
    }
    private void scaleAsteroid(Rigidbody asteroidRB, GameObject newAsteroid)
    {
        StartCoroutine(scaleTimer());
        IEnumerator scaleTimer()
        {
            for (int i = 0; i < 14; i++)
            {
                if(asteroidRB == null)
                {
                    break;
                }
                asteroidRB.transform.localScale += new Vector3(.05f, .05f, .05f);
                yield return new WaitForSeconds(.1f);
            }
            
        }
        StartCoroutine(deleteAsteroid());
        IEnumerator deleteAsteroid()
        {
           
            yield return new WaitForSeconds(5f);
            Destroy(newAsteroid);
            

        }


    }
}
