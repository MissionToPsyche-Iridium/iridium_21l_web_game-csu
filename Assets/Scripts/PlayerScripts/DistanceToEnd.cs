using UnityEngine;
using UnityEngine.SceneManagement;

public class DistanceToEnd : MonoBehaviour
{
    public GameObject Cylinder;
    public GameObject End;
    public static float distance;
    public static bool gameWon;

    public void Update()
    {
        distance = Vector3.Distance(Cylinder.transform.position, End.transform.position);
        // Debug.Log("Distance until end " + (distance - 10));

        if(distance < 10){
            Debug.Log("Congrats!");
            gameWon = true;
            SceneManager.LoadScene(4);
        }
    }
}