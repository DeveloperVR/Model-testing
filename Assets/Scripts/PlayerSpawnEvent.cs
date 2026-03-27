using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerSpawnEvent : MonoBehaviour
{
    public UnityEvent OnPlayerSpawned; // Evento que se invoca cuando el jugador es generado.

    public bool playerSpawned = false; // Bandera para verificar si el jugador ya ha sido generado.

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(WaitForSpawn());
    }

    IEnumerator WaitForSpawn()
    {
        while (!playerSpawned)
        {
            yield return null; // Espera un frame antes de volver a comprobar.
        }

        OnPlayerSpawned.Invoke(); // Invoca el evento cuando el jugador ha sido generado.
        Debug.Log("Player has been spawned and event invoked.");
    }
}
