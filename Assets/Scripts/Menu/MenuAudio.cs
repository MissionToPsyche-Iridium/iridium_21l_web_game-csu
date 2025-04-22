using UnityEngine;

public class MenuAudio: MonoBehaviour {
    public AudioSource menuButtonHover; //multiple audiosources allow multiple sounds to play at once
    public AudioSource menuButtonClick; //multiple audiosources also ensure that other audio clips dont overwrite each other while playing
    public AudioClip hover;
    public AudioClip click;
    private static MenuAudio instance;
    void Awake() {
        instance = this;
    }
    void Start() {
        if (menuButtonHover == null || menuButtonClick == null)
        {
            Debug.LogError("check audiosources in inspector");
        }
    }

    void Update() {
        //Boost Sound
        if (Input.GetKeyDown(KeyCode.LeftShift)) { 
                PlayHoverSound();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift)) { 
            if (!menuButtonHover.isPlaying)
                PlayClickSound();
        }
    }
    public static void PlayHoverSound() {
        instance.menuButtonHover.clip = instance.hover;
        instance.menuButtonHover.loop = false;
        instance.menuButtonHover.Play();
    }
    public static void PlayClickSound() {
        instance.menuButtonClick.clip = instance.click;
        instance.menuButtonClick.loop = false;
        instance.menuButtonClick.Play();
    }
}