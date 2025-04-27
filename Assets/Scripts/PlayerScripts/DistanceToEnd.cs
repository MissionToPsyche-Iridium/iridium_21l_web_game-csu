using UnityEngine;
using UnityEngine.SceneManagement;

public class DistanceToEnd : MonoBehaviour
{
    //initialize vars
    public GameObject Cylinder;
    public GameObject End;
    public static float distance;
    public static bool gameWon;

    public void Update()
    {
        //set distance equal to float using built in method
        distance = Vector3.Distance(Cylinder.transform.position, End.transform.position);

        //if distance is < 10, load victory scene.
        if(distance < 10){
            gameWon = true;
            SceneManager.LoadScene(4);
        }
    }
}