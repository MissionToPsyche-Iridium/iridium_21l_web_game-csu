using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnAsteroidEndless : MonoBehaviour
{
    //initialize vars
    private Vector3 playerRot;
    private Transform playerT;
    public GameObject asteroid;
    public GameObject health;
    public Transform asteroidSpawnerTransform;
    public Transform playerPos;
    private GameObject newAsteroid;
    private GameObject newHealth;
    private Rigidbody healthRB;
    private Rigidbody asteroidRB;
    private float waitTime = 0f;
    private float timer = 0.0f;
    private float ranX, ranY,ranSpeed = 0.0f;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //set object equal to player transform, and randomly generate a wait time
        playerT = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        waitTime = Random.Range(1.0f, 4.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //set var equal to current player rotation
        playerRot = playerT.rotation.eulerAngles;
        //if not in cutscene start timer and continute with the rest
        if (!spawnScript.cutscene) 
        { 
        timer += Time.deltaTime;
        //if timer is above wait time, reset timer
        if (timer > waitTime)
        {

            timer -= waitTime;
            //randomly generate x,y, and speed values, then have the meteoroid spawner look at the player and then turn based on the x and y, and shoot meteoroid at random speed
            ranX = Random.Range(-7f, 7f);
            ranY = Random.Range(-7f, 7f);
            ranSpeed = Random.Range(10f, 25f);
            asteroidSpawnerTransform.LookAt(playerPos);
            asteroidSpawnerTransform.rotation *= Quaternion.Euler(ranX,ranY, 0f);
            //if player is missing health, have 5% chance to spawn a heart
            if (CheckHit.playerHealth < 3 && Random.Range(0,100) < 6)
                {
                    spawnHealth();
                }
            else
                {
                    spawnAsteroid();
                }
            waitTime = Random.Range(1.0f, 4.0f);

        }
   
        }
        
    }
    //spawn meteoroid with random speed and rotation
    private void spawnAsteroid()
    {
        newAsteroid = Instantiate(asteroid, asteroidSpawnerTransform.position, asteroidSpawnerTransform.rotation);
        asteroidRB = newAsteroid.GetComponent<Rigidbody>();
        scaleAsteroid(asteroidRB, newAsteroid);
        
        asteroidRB.linearVelocity = asteroidRB.transform.TransformDirection(Vector3.forward * ranSpeed);
    }
    //spawn health with random speed at random rotation
    private void spawnHealth()
    {
        newHealth = Instantiate(health, asteroidSpawnerTransform.position, asteroidSpawnerTransform.rotation);
        healthRB = newHealth.GetComponent<Rigidbody>();

        healthRB.linearVelocity = healthRB.transform.TransformDirection(Vector3.forward * ranSpeed);
    }
    //slowly scale the meteoroid as it comes closer to player to make it appear as if it is coming from further away, and destroy after 10 seconds for optimization.
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
                asteroidRB.transform.localScale += new Vector3(.1f, .1f, .1f);
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
