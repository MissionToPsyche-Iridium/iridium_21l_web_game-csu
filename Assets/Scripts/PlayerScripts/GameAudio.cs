using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using NUnit.Framework;

public class GameAudio : MonoBehaviour {
    public Transform playerPosition;
    public Vector3 playerPositionVector;
    public AudioClip boost;
    public AudioClip healthIsNow2;
    public AudioClip healthIsNow3;
    public AudioClip hit1;
    public AudioClip hit2;
    public AudioClip slingshot;
    public bool hasPlayed = false;
    void Update() {
        playerPositionVector = new Vector3(playerPosition.position.x,playerPosition.position.y,playerPosition.position.z);
        if(MoveShip.isSlingshot && !hasPlayed) {
            AudioSource.PlayClipAtPoint(slingshot, playerPositionVector, 100f);
            hasPlayed = true;
        }
    }
}