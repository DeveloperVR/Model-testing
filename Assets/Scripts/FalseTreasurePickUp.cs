
using System.Collections;
using Unity.XR.CoreUtils;
using UnityEngine;

using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class FalseTreasurePickUp : MonoBehaviour
{



    // This class can be used to handle interactions with false treasure pickups
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Aquí puedes agregar lógica para sumar puntos o actualizar el inventario del jugador
            StartCoroutine(LockPlayerPosition(other.gameObject));
            Debug.Log("Nombre del componente del jugador: " + other.gameObject.name);
            Debug.Log("Cofre falso recogido! El jugador ha sido inmovilizado por 3 segundos.");

            // Destruir el objeto del tesoro después de recogerlo
            gameObject.SetActive(false);
        }else if (other.gameObject.CompareTag("VRPlayer"))
        {
            // Aquí puedes agregar lógica para sumar puntos o actualizar el inventario del jugador
            GameObject Movement = other.gameObject.GetNamedChild("Move");
            GameObject Teleportation = other.gameObject.GetNamedChild("Teleportation");
            StartCoroutine(LockVRPlayerPosition(Movement, Teleportation));
            Debug.Log("Nombre del componente del jugador VR: " + other.gameObject.name);
            Debug.Log("Cofre falso recogido! El jugador ha sido inmovilizado por 3 segundos.");

            // Destruir el objeto del tesoro después de recogerlo
            
        }
    }

    IEnumerator LockPlayerPosition(GameObject Player)
    {
        Vector3 lockedPosition = Player.transform.position;

        float duration = 3f;
        float timer = 0f;

        while (timer < duration)
        {
            Player.GetComponent<CharacterController>().enabled = false;
            Player.transform.position = transform.position;
            timer += Time.deltaTime;
            yield return null;
        }
        Player.GetComponent<CharacterController>().enabled = true;
    }

    IEnumerator LockVRPlayerPosition(GameObject Movement, GameObject Teleportation)
    {
        float duration = 3f;
        float timer = 0f;
        Movement.GetComponent<DynamicMoveProvider>().enabled = false;
        Teleportation.GetComponent<UnityEngine.XR.Interaction.Toolkit.Locomotion.Teleportation.TeleportationProvider>().enabled = false;
        
        while (timer < duration)
        {
            
            timer += Time.deltaTime;
            Debug.Log("Tiempo transcurrido: " + timer);
            yield return null;
        }
        Debug.Log("Habilitando movimiento VR nuevamente");
        Movement.GetComponent<DynamicMoveProvider>().enabled = true;
        Teleportation.GetComponent<UnityEngine.XR.Interaction.Toolkit.Locomotion.Teleportation.TeleportationProvider>().enabled = true;
        gameObject.SetActive(false);
    }
}
