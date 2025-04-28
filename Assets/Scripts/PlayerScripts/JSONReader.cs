using UnityEngine;

public class JSONReader : MonoBehaviour
{
    public TextAsset JSON;
    //class for all vars from JSON
    public class Ship
    {
        public float shipSpeed;
        public float waitTimeBoundary;
        public float cutsceneTime;
        public float healthRotateSpeed;
    }

    //create obj to retrieve json values
    public static Ship shipOBJ = new Ship();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //read from json file and store into obj.
        shipOBJ = JsonUtility.FromJson<Ship>(JSON.text);
    }
    
}
