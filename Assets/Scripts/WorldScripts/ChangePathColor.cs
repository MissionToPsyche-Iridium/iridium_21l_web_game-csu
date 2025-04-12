using NUnit.Framework.Internal;
using System.Collections;
using UnityEngine;

public class ChangePathColor : MonoBehaviour
{
    private float timer = 0.0f;
    private float waitTime = 5.0f;
    private bool isBlue = true;
    public Material glowMaterial;
    private Color blue = new Color (0.0f, 1.0f, 1.0f, 1.0f);
    private Color red = new Color(1.0f, 0.0f, 0.0f, 1.0f);
    private Color redInvis = new Color(1.0f, 0.0f, 0.0f, 0.0f);
    private Color blueInvis = new Color(0.0f, 1.0f, 1.0f, 0.0f);
    private bool isCoroutineRunning = false;
    private float lerpTimer = 0.0f;
    private bool shouldFade = true;
    private bool shouldChangeColor = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        glowMaterial.color = blue * 2f;
        glowMaterial.SetColor("_EmissionColor", blue);
    }

    // Update is called once per frame
    //https://discussions.unity.com/t/setting-emission-color-programatically/152813
    void Update()
    {

        timer += Time.deltaTime;
        if (timer > waitTime && shouldFade)
        {
            lerpTimer += Time.deltaTime;
            if (isBlue)
            {
                glowMaterial.color = Color.Lerp(glowMaterial.color, blueInvis, lerpTimer * .05f);
            }
            if (!isCoroutineRunning) { 
                StartCoroutine(WaitTime());  
            }

        }
        if (timer > waitTime && shouldChangeColor)
        {
            
            if (isBlue)
            {
                lerpTimer += Time.deltaTime;
                glowMaterial.color = Color.Lerp(glowMaterial.color, blue * 2f, lerpTimer * .01f);
                glowMaterial.SetColor("_EmissionColor", blue);
                if (!isCoroutineRunning) { StartCoroutine(WaitTime()); }
            }
            
            
            
        }
       
    }
    IEnumerator WaitTime()
    {

        isCoroutineRunning = true;
        yield return new WaitForSeconds(1.5f);
        if (shouldFade)
        {
            shouldChangeColor = true;
            shouldFade = false;
            lerpTimer = 0.0f;
        }
        else if (shouldChangeColor)
        {

            shouldChangeColor = false;
            shouldFade = true;
            timer = 0.0f;
            lerpTimer = 0.0f;
        }
        
        isCoroutineRunning = false;
    }
}
