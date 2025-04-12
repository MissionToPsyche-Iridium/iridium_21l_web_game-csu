using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnAsteroid : MonoBehaviour
{
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
        playerT = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        waitTime = Random.Range(3.0f, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        playerRot = playerT.rotation.eulerAngles;
        if (!spawnScript.cutscene) 
        { 
        timer += Time.deltaTime;

        if (timer > waitTime)
        {
            timer -= waitTime;
            //ranX = Random.Range(-15f, 15f);
            //ranY = Random.Range(175f, 185f);
            ranX = Random.Range(-15f, 15f);
            ranY = Random.Range(-15f, 15f);
            ranSpeed = Random.Range(10f, 20f);
            asteroidSpawnerTransform.LookAt(playerPos);
            //asteroidSpawnerTransform.rotation = Quaternion.Euler(-playerRot.x + ranX, playerRot.y + ranY, 0f);
            asteroidSpawnerTransform.rotation *= Quaternion.Euler(ranX,ranY, 0f);
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

        healthRB.linearVelocity = healthRB.transform.TransformDirection(Vector3.forward * ranSpeed);
       // rotateHealth(healthRB, newHealth);
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
