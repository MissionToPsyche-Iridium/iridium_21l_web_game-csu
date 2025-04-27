using System.Collections;
using UnityEngine;

public class SlingshotWarning : MonoBehaviour
{
    //initialize vars
    public GameObject textWarning;
    private bool waitOff = false;
    public void Start()
    {
        //make sure is off at start
        textWarning.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {
        //if object in trigger sling warning start coroutine
        if (other.CompareTag("SlingWarning"))
        {
            if (waitOff == false)
            {
                StartCoroutine(waitTurnOff());
            }
            
        }
    }
    //if out of trigger, turn off warning
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SlingWarning"))
        {
            textWarning.SetActive(false);
        }
    }
    //constantly iterate between visible and invisible text to flash a warning text on and off.
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
