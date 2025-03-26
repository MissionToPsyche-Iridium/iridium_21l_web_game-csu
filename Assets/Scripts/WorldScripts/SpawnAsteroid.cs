using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnAsteroid : MonoBehaviour
{
    
    public GameObject asteroid;
    public GameObject health;
    public Transform asteroidSpawnerTransform;
    private GameObject newAsteroid;
    private GameObject newHealth;
    private Rigidbody healthRB;
    private Rigidbody asteroidRB;
    private float waitTime = 0f;
    private float timer = 0.0f;
    private float ranX, ranY,ranSpeed = 0.0f;
    private float random_numb;

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
            if (CheckHit.playerHealth < 3 && Random.Range(0,101) < 6)
                {
                    spawnHealth();
                }
            else
                {
                    spawnAsteroid();
                }
            waitTime = Random.Range(3.0f, 10.0f);

        }
   
        }
        
    }

    private void spawnAsteroid()
    {
        newAsteroid = Instantiate(asteroid, asteroidSpawnerTransform.position, asteroidSpawnerTransform.rotation);
        asteroidRB = newAsteroid.GetComponent<Rigidbody>();
        scaleAsteroid(asteroidRB, newAsteroid);
        
        asteroidRB.linearVelocity = asteroidRB.transform.TransformDirection(Vector3.forward * ranSpeed);
    }
    private void spawnHealth()
    {
        newHealth = Instantiate(health, asteroidSpawnerTransform.position, asteroidSpawnerTransform.rotation);
        healthRB = newHealth.GetComponent<Rigidbody>();
       // rotateHealth(healthRB, newHealth);
    }

    private void scaleAsteroid(Rigidbody asteroidRB, GameObject newAsteroid)
    {
        StartCoroutine(scaleTimer());
        IEnumerator scaleTimer()
        {
            random_numb = Random.Range(.05f,.1f);
            
            for (int i = 0; i < 20; i++)
            {
                if (asteroidRB == null)
                {
                    yield break; // Stop scaling if the asteroid is destroyed
                }

                newAsteroid.transform.localScale += new Vector3(random_numb, random_numb, random_numb);
                yield return new WaitForSeconds(.1f);
            }

        }
        StartCoroutine(deleteAsteroid());
        IEnumerator deleteAsteroid()
        {
           
            yield return new WaitForSeconds(10f);
            Destroy(newAsteroid);
            

        }


    }
}
