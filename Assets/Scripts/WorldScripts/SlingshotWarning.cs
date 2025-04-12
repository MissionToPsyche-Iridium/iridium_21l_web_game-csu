using System.Collections;
using UnityEngine;

public class SlingshotWarning : MonoBehaviour
{
    public GameObject textWarning;
    private bool waitOn = false;
    private bool waitOff = false;
    private int counter = 0;
    public void Start()
    {
        textWarning.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {
      
        if (other.CompareTag("SlingWarning"))
        {
            if (waitOff == false)
            {
                StartCoroutine(waitTurnOff());
            }
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SlingWarning"))
        {
            textWarning.SetActive(false);
        }
    }

    IEnumerator waitTurnOff()
    {
        waitOff = true;
        textWarning.SetActive(true);
        yield return new WaitForSeconds(1f);
        textWarning.SetActive(false);
        yield return new WaitForSeconds(1f);
        waitOff = false;
    }

}
