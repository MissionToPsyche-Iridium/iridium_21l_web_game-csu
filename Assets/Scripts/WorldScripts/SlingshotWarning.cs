using UnityEngine;

public class SlingshotWarning : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("SlingWarning"))
        {
            Debug.Log("Mars orbit slingshot incoming, prepare for high speeds.");
        }
    }
}
