using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRotation : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private GameObject spriteObject;

    void Update()
    {
         // Obtener la dirección hacia la que mira la cámara
        Vector3 forward = cameraTransform.forward;
        forward.y = 0; // Mantener horizontal
        if (forward.sqrMagnitude > 0.001f)
        {
            spriteObject.transform.rotation = Quaternion.LookRotation(forward) * Quaternion.Euler(90, 0, 0);
        }
    }
}
