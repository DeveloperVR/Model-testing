using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class FreeRoamPlayerSpawnEvent : MonoBehaviour
{
    public UnityEvent OnVRPlayerSpawned; // Evento que se invoca cuando el jugador es generado.

    public UnityEvent OnNonVRPlayerSpawned; // Evento que se invoca cuando el jugador es generado.

    public bool playerSpawned = false; // Bandera para verificar si el jugador ya ha sido generado.
    public bool isVRPlayer = false; // Bandera para verificar si el jugador es VR o no.
    public bool isNonVRPlayer = false; // Bandera para verificar si el jugador es no VR o no.


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

        if (isVRPlayer)
        {
            OnVRPlayerSpawned.Invoke(); // Invoca el evento cuando el jugador VR ha sido generado.
            Debug.Log("VR Player has been spawned and event invoked.");
        }
        else if (isNonVRPlayer)
        {
            OnNonVRPlayerSpawned.Invoke(); // Invoca el evento cuando el jugador no VR ha sido generado.
            Debug.Log("Non-VR Player has been spawned and event invoked.");
        }
    }
}
