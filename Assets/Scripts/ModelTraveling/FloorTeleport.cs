using UnityEngine;

public class FloorTeleport : MonoBehaviour
{

    public Transform teleportTarget; // The target position to teleport to
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TeleportPlayer(other.gameObject);
        }
        else
        {
            Debug.Log("Non-player object entered the teleport area.");
        }
    }

    private void TeleportPlayer(GameObject player)
    {
        if (teleportTarget != null)
        {
            player.transform.position = teleportTarget.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Player exited the teleport area.");
    }

}
