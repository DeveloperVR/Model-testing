using UnityEngine;

public class PlayerObjSync : MonoBehaviour
{
    public Transform playerObj;

    void LateUpdate()
    {
        // Mantener al modelo siempre en el origen local del jugador
        playerObj.localPosition = Vector3.zero;
        playerObj.localRotation = Quaternion.identity;
    }
}
