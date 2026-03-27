using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    Transform mainCamera;

    void Start()
    {
        mainCamera = Camera.main.transform;
    }

    void Update()
    {
        // el texto siempre mira al usuario.
        //transform.rotation = Quaternion.LookRotation(transform.position - mainCamera.position);
    }
}
