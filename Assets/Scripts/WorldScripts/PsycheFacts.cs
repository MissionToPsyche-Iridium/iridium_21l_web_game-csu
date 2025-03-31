using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;
public class PsycheFacts : MonoBehaviour
{
    //https://www.youtube.com/watch?v=8oTYabhj248
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public GameObject marsSlingshotBoundary;
    private int index;
    private bool isTextDone = false;
    public Button understoodButton;
    public GameObject UIPanel;
    private float tempSensitivity;
    Dictionary<int, string> psycheFacts = new Dictionary<int, string>()
    {
        {1, "By August 2029 the Psyche spacecraft will begin exploring the asteroid that scientists think – because of its high metal content – may be the partial core of a planetesimal, a building block of an early planet." },
        {2, "The Psyche spacecraft launched Oct. 13, 2023, at 10:19 a.m. EDT from Kennedy Space Center. Psyche lifted off from Launch Pad 39A aboard a SpaceX Falcon Heavy rocket." },
        {3, "The body of the Psyche spacecraft is about the size of a small van, and it’s powered by solar electric propulsion." },
        {4, "The Psyche spacecraft has a magnetometer, a gamma-ray and neutron spectrometer, and a multispectral imager to study asteroid Psyche. The spacecraft will start sending images to Earth as soon as it spots the asteroid. " },
        {5, "At launch, the Psyche spacecraft had a mass of 6,056 pounds or 2,747 kilograms." },
        {6, "The Psyche spacecraft’s body, or bus is 16.1 feet (4.9 meters) tall, 7.1 feet (2.2 meters) wide, and 7.8 feet (2.4 meters) deep." },
        {7, "With its solar panels deployed at 81 feet (25 meters) by 24 feet (7.3 meters), Psyche just about covers a tennis court." },
        {8, "The solar arrays on Psyche spacecraft produce 21 kilowatts of power when leaving the Earth and between 2.3 and 3.4 kilowatts of power during orbit around the asteroid." },
        {9, "The Psyche spacecraft has four Hall-effect thrusters that use electromagnetic fields to expel charged atoms, or ions, of inert xenon gas that in turn create thrust, trailing a blue glow of xenon." },
        {10, "The Psyche spacecraft communicates with Earth with four antennas: one 6.5-foot (2-meter) fixed high-gain antenna provided by Maxar and three small low-gain antennas designed and manufactured by JPL." },
        {11, "Like all NASA interplanetary missions, the Psyche spacecraft sends data and receives commands through the Deep Space Network (DSN), which has three ground stations around Earth to talk with and track spacecraft." },
        {12, "The Psyche spacecraft’s multispectral imager consists of a pair of identical cameras equipped with filters and telescopic lenses to photograph the surface of the asteroid in different wavelengths of light." },
        {13, "The Psyche spacecraft’s spectrometer can detect emissions from cosmic rays and high energy particles bombarding the asteroid Psyche’s surface, the elements there absorb the energy, enabling scientists to match them to properties of known elements to determine what asteroid is made of." },
        {14, "This is NASA’s first mission to study an asteroid that has more metal than rock or ice." },
        {15, "Scientists think asteroid Psyche, which is about 173 miles (280 kilometers) at its widest point, could be part or all of the iron-rich core of a planetesimal, a building block of a rocky planet." },
        {16, "The asteroid Psyche may be able to show us how Earth’s core and the cores of the other terrestrial planets came to be." },
        {17, "The asteroid Psyche was discovered in 1852 by Italian astronomer Annibale de Gasparis. Because it was the 16th asteroid to be discovered, it is sometimes referred to as 16 Psyche." },
        {18, "The asteroid Psyche orbits the Sun in the outer part of the main asteroid belt between Mars and Jupiter. It is approximately three times farther from the Sun than Earth." },
        {19, "The asteroid Psyche and Earth orbit at different speeds, the distance from Earth to the asteroid varies from less than 186 million miles to more than 372 million miles." },
        {20, "The asteroid Psyche is dense, estimated at about 212 to 256 pounds per cubic foot (3,400 to 4,100 kilograms per cubic meter)." },
        {21, "The surface gravity on the asteroid Psyche is much less than it is on Earth – even less than it is on Earth’s Moon. On the asteroid, lifting a car would feel like lifting a large dog." },
        {22, "Scientists think the asteroid Psyche may consist of significant amounts of metal from the core of a planetesimal, one of the building blocks of our solar system. The asteroid is most likely a survivor of multiple violent hit-and-run collisions, common when the solar system was forming." },
        {23, "There are still contradictions in the data, but scientific analysis indicates that the asteroid Psyche is likely made of a mixture of rock and metal, with metal composing 30% to 60% of its volume." },
        {24, "Visiting the asteroid Psyche could provide a one-of-a-kind window into the violent history of collisions and accumulation of matter that created planets like our own." },
        {25, "The asteroid Psyche takes 4.2 hours to complete one full rotation." },
        {26, "The asteroid Psyche takes 5 years to complete one full solar orbit." },
        {27, "The Psyche spacecraft’s magnetometer will look for evidence of an ancient magnetic field at asteroid Psyche, and confirmation of a remanent magnetic field at the asteroid Psyche would be strong evidence that the asteroid formed from the core of a planetary body." }
    };
    private List<int> numPicker = new List<int>{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27};
    private List<int> tempList = new List<int>();
    int i = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        understoodButton.gameObject.SetActive(false);
        UIPanel.SetActive(false);
        for (int j = 0; j < 27; j++)
        {
            tempList.Add(numPicker[j]);
        }


    }

    // Update is called once per frame
    void Update()
    {
       if (isTextDone)
        {
            Cursor.lockState = CursorLockMode.None;
            understoodButton.gameObject.SetActive(true);
        }
    }

    public void understoodButtonFunct()
    {
        Cursor.lockState = CursorLockMode.Locked;
        textComponent.text = string.Empty;
        isTextDone = false;
        understoodButton.gameObject.SetActive(false);
        UIPanel.SetActive(false);
        GetComponent<RotateShip>().enabled = true;
        Time.timeScale = 1f;
    }
    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.collider.CompareTag("Asteroid"))
        {
            GetComponent<RotateShip>().enabled = false;
            int tempIndex = 0;
            i = UnityEngine.Random.Range(0, tempList.Count);
            tempIndex = tempList[i];
            textComponent.text = string.Empty;
            lines[0] = psycheFacts[tempIndex];
            startDialogue();
            UIPanel.SetActive(true);
            MoveShip.isSlingshot = false;
            //marsSlingshotBoundary.transform.position = new Vector3(0, 1000f);
            Time.timeScale = 0;

            
           

            Debug.Log(psycheFacts[tempIndex]);
            tempList.RemoveAt(i);
            
        }
        if (tempList.Count == 0)
        {
            for (int j = 0; j < 27; j++)
            {
                tempList.Add(numPicker[j]);
            }
        }
    }

    void startDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSecondsRealtime(textSpeed);
        }
        Debug.Log("DONE");
        isTextDone = true;
    }
}
