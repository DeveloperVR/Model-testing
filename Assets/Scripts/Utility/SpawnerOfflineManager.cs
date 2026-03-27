using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerOfflineManager : MonoBehaviour
{
    GameObject SpawnerEvent;
    void Start()
    {
        SpawnerEvent = GameObject.Find("PlayerSpawnEvent");
        SpawnerEvent.GetComponent<PlayerSpawnEvent>().playerSpawned = true; // Set the playerSpawned flag to true to trigger the event
    }

    
}
