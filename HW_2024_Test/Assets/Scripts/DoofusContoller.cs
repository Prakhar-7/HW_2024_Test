using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DoofusController : MonoBehaviour
{
    private float moveSpeed;
    public float horizontalInput;
    public float verticalInput;
    //public DoofusDiary doofusDiary;
    public TextAsset DoofusJSON;


    [System.Serializable]
    public class GameData
    {
        public PlayerData player_data;
    }

    [System.Serializable]
    public class PlayerData
    {
        public float speed;
    }

    void Start()
    {
        //LoadDoofusDiary();
        //ApplyGameSettings();

        // Parse the JSON into a GameData object
        GameData gameData = JsonUtility.FromJson<GameData>(DoofusJSON.text);

        // Extract the speed from the player_data section and assign it to moveSpeed
        moveSpeed = gameData.player_data.speed*3;

        // Print the speed to verify
        Debug.Log("Player Speed: " + moveSpeed);

    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * verticalInput);
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * horizontalInput);
    }

}
