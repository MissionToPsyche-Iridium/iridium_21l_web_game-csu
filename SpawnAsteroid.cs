using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnAsteroid : MonoBehaviour
{

    private float random_numb;
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
        if (!spawnScript.cutscene) 
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
        
    }

    private void spawnAsteroid()
    {
        newAsteroid = Instantiate(asteroid, asteroidSpawnerTransform.position, asteroidSpawnerTransform.rotation);
        asteroidRB = newAsteroid.GetComponent<Rigidbody>();

        // Randomize the size of the asteroid by scaling it
        float randomScale = Random.Range(0.5f, 10.0f); // Random scale between 0.5 and 3 times the original size
        newAsteroid.transform.localScale = new Vector3(randomScale, randomScale, randomScale);

        // Start scaling and deletion processes
        StartCoroutine(ScaleAsteroid(asteroidRB, newAsteroid));
        StartCoroutine(DeleteAsteroid(newAsteroid));

        asteroidRB.linearVelocity = asteroidRB.transform.TransformDirection(Vector3.forward * ranSpeed);
    }
    private IEnumerator ScaleAsteroid(Rigidbody asteroidRB, GameObject newAsteroid)
    {
        random_numb = Random.Range(7f, 35f);

        for (int i = 0; i < random_numb; i++)
        {
            if (asteroidRB == null)
            {
                yield break; // Stop scaling if the asteroid is destroyed
            }

            newAsteroid.transform.localScale += new Vector3(.05f, .05f, .05f);
            yield return new WaitForSeconds(.1f);
        }
    }

    private IEnumerator DeleteAsteroid(GameObject newAsteroid)
    {
        yield return new WaitForSeconds(5f);

        if (newAsteroid != null)
        {
            Destroy(newAsteroid);
        }


    }
}
