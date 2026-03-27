using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingPlayers : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform spawnPoint;
    void Awake()
    {
        PlacePlayer();
    }

    public void PlacePlayer()
    {
        if (playerPrefab != null && spawnPoint != null)
        { 
            playerPrefab.transform.position = spawnPoint.position;
            playerPrefab.transform.rotation = spawnPoint.rotation; // Optional: Reset rotation
        }
    }
}
