using UnityEngine;

public class GameAudio : MonoBehaviour {
    public AudioSource audioSourceBoost;
    public AudioSource audioSourceHit1;
    public AudioSource audioSourceHit2; //multiple audiosources allow multiple sounds to play at once
    public AudioSource audioSourceSlingshot; //multiple audiosources also ensure that other audio clips dont overwrite each other while playing
    public AudioSource audioSourceHeal;
    public AudioClip boost;
    public AudioClip hit1;
    public AudioClip hit2;
    public AudioClip slingshot;
    public AudioClip heal;
    private static GameAudio instance;
    void Awake() {
        instance = this;
    }
    void Start() {
        if (audioSourceBoost == null || audioSourceHit1 == null || audioSourceHit2 == null || audioSourceSlingshot == null)
        {
            Debug.LogError("check audiosources in inspector");
        }
    }

    void Update() {
        //Boost Sound
        if (Input.GetKeyDown(KeyCode.LeftShift))
        { //boost should play as long as it isnt already playing, if the cutscene is inactive, as long as the player is able to boost, and if the player is already moving (pressing W)
            if (!audioSourceBoost.isPlaying && 
            spawnScript.cutscene == false && 
            MoveShip.boost_value > 0 && 
            Input.GetKey(KeyCode.W))

                PlayBoostSound();
        }
    }
    public static void PlayBoostSound() {
        instance.audioSourceBoost.clip = instance.boost;
        instance.audioSourceBoost.loop = false;
        instance.audioSourceBoost.Play();
    }
    public static void PlayHitSounds() {
        // play hit 1
        instance.audioSourceHit1.clip = instance.hit1;
        instance.audioSourceHit1.loop = false;
        instance.audioSourceHit1.Play();
        // play hit 2 simultaneously
        instance.audioSourceHit2.clip = instance.hit2;
        instance.audioSourceHit2.loop = false;
        instance.audioSourceHit2.Play();
    }
    public static void PlaySlingshotSound() {
        instance.audioSourceSlingshot.clip = instance.slingshot;
        instance.audioSourceSlingshot.loop = false;
        instance.audioSourceSlingshot.Play();
    }
    public static void PlayHealSound() {
        // play when player gains a heart
        instance.audioSourceHeal.clip = instance.heal;
        instance.audioSourceHeal.loop = false;
        instance.audioSourceHeal.Play();
    }
}