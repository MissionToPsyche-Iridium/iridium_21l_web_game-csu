using System.Collections;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Timers;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckHit : MonoBehaviour
{
    public ParticleSystem explosionParticles;
    private ParticleSystem newParticles;
    public new Camera camera;
    /*
    private float elapsed = 0f;
    private float currentMagnitude = 1f;
    private float playerX;
    private float playerY;
    */
    private GameObject health1;
    private GameObject health2;
    private GameObject health3;
    private bool isHit = false;
    public static int playerHealth = 3;
    private float localTimer;
    private float waitTimer = 1f;
    private int firstCheck;
    Coroutine timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHealth = 3;
        health1 = GameObject.FindGameObjectWithTag("Health1");
        health2 = GameObject.FindGameObjectWithTag("Health2");
        health3 = GameObject.FindGameObjectWithTag("Health3");
    }

    // Update is called once per frame
    void Update()
    {

        if (playerHealth < 1)
        {
            SceneManager.LoadScene(5);
        }

        if (MoveShip.isSlingshot) 
        {
            if (firstCheck == 0)
            {
                timer = StartCoroutine(ShakeCameraSlingshot(1f));
                firstCheck = 1;
            }
            
            localTimer += Time.deltaTime;
            if (localTimer > waitTimer)
            {
                localTimer = 0.0f;
                timer = StartCoroutine(ShakeCameraSlingshot(1f));
            }
        }
        if (!MoveShip.isSlingshot)
        {
            firstCheck = 0;
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
      
        if (other.CompareTag("RegenHealth"))
        {
            if (playerHealth == 2)
            {
                health3.SetActive(true);
                playerHealth += 1;
            }
            else if (playerHealth == 1)
            {
                health2.SetActive(true);
                playerHealth += 1;
            }
            Destroy(other.transform.root.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.CompareTag("Asteroid"))
        {

            //checks if player is already hit, if so stop previous camera shake and start a new one
            if (isHit)
            {
                StopCoroutine(timer);
            }

            timer = StartCoroutine(ShakeCamera(1f));
            playerHealth -= 1;
            if (playerHealth == 2)
            {
                health3.SetActive(false);
            }
            else if (playerHealth == 1)
            {
                health2.SetActive(false);
            }
            else if (playerHealth == 0)
            {
                health1.SetActive(false);


            }
            newParticles = Instantiate(explosionParticles, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            //Debug.Log("REACHED");
            Destroy(collision.gameObject);
        }


    }
    //https://www.youtube.com/watch?v=lq7y0thMN1M
    IEnumerator ShakeCamera(float duration)
    {
        
        float elapsed = 0f;
        float currentMagnitude = 1f;
        float playerX;
        float playerY;
        while (elapsed < duration)
        {
            isHit = true;
            playerX = (Random.value - .5f) * currentMagnitude;
            playerY = (Random.value - .5f) * currentMagnitude;
            camera.transform.localPosition = new Vector3(playerX + 0.1299985f, playerY + 0.7100105f, 2.41901f);

            elapsed += Time.unscaledDeltaTime;
            currentMagnitude = (1 - (elapsed / duration)) * (1 - (elapsed / duration));


            yield return null;
        }
        isHit = false;
        camera.transform.localPosition = new Vector3(0.1299985f, 0.7100105f, 2.41901f);

    }
    IEnumerator ShakeCameraSlingshot(float duration)
    {

        float elapsed = 0f;
        float currentMagnitude = .25f;
        float playerX;
        float playerY;
        while (elapsed < duration)
        {
            playerX = (Random.value - .5f) * currentMagnitude;
            playerY = (Random.value - .5f) * currentMagnitude;
            camera.transform.localPosition = new Vector3(playerX + 0.1299985f, playerY + 0.7100105f, 2.41901f);
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }
        camera.transform.localPosition = new Vector3(0.1299985f, 0.7100105f, 2.41901f);
    }
}
