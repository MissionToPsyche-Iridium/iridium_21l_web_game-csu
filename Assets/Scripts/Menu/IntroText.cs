using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class IntroText : MonoBehaviour
{
    //initialize vars
    //used same dialouge tutorial used in psyche facts script to display text across screen
    //https://www.youtube.com/watch?v=8oTYabhj248
    public TextMeshProUGUI textStory1;
    public TextMeshProUGUI textStory2;
    public string[] lines;
    public float textSpeed;
    private int counter = 0;
    public InputAction storySpace;
    private bool isDialougeRunning1 = false;
    private bool isDialougeRunning2 = false;
    void Start()
    {
        textStory1.text = string.Empty;
        textStory2.text = string.Empty;
        storySpace = InputSystem.actions.FindAction("StorySpace");
        

    }
    void Update() //checks if there is more text to be "typed"
    {
        //check counter that increments every time space or left click is pressed for skipping, once each text box is done displaying go next until it loads game scene.
        if (counter == 0)
        {
            if (!isDialougeRunning1)
            {
                startDialogue();
            }
            
        }
        else if (counter == 1)
        {
            if (!isDialougeRunning2)
            {
                StopAllCoroutines();
                textStory1.text = string.Empty;
                textStory2.text = string.Empty;
                startDialogue();
            }
        }
        else if (counter == 2)
        {
           SceneManager.LoadScene(1);
        }
        if (storySpace.triggered)
        {
            counter++;
        }
        
    }

    void startDialogue()
    {
        StartCoroutine(TypeLine());
    }

    //display each text box respective to the counter.
    IEnumerator TypeLine()

    {
        
        if (counter == 0)
        {
            isDialougeRunning1 = true;
            foreach (char c in lines[0].ToCharArray())
            {
                textStory1.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
            yield return new WaitForSeconds(5f);
            counter += 1;
        }
        else if (counter == 1)
        {
            isDialougeRunning2 = true;
            foreach (char c in lines[1].ToCharArray())
            {
                textStory2.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
            yield return new WaitForSeconds(5f);
            counter += 1;
        }

    }
}
