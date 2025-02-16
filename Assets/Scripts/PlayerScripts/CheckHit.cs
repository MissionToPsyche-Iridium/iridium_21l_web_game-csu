using System.Collections;
using System.Runtime.CompilerServices;
using System.Timers;
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
    private bool isHit = false;
    private int playerHealth = 3;
    Coroutine timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth < 1) {
            SceneManager.LoadScene(5);
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
                Destroy(GameObject.FindGameObjectWithTag("Health3"));
            }
            else if (playerHealth == 1)
            {
                Destroy(GameObject.FindGameObjectWithTag("Health2"));
            }
            else if (playerHealth == 0)
            {
                Destroy(GameObject.FindGameObjectWithTag("Health1"));
                Debug.Log("Game Over");
                
            }
            newParticles = Instantiate(explosionParticles, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Debug.Log("REACHED");
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
            camera.transform.localPosition = new Vector3(playerX, playerY+.384f, 1.612f);

            elapsed += Time.deltaTime;
            currentMagnitude = (1 - (elapsed / duration)) * (1 - (elapsed / duration));

            
            yield return null;
        }
        isHit = false;
        camera.transform.localPosition = new Vector3(0f, 0.384f, 1.612f);
    }


   
}
