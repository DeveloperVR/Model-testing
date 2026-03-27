using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    // Start is called before the first frame update
    private bool Activated = false;

    void OnTriggerEnter(Collider other)
    {
        if (Activated == false)
        {
            Debug.Log("Recorrido iniciado");
            Activated = true;
            return;
        }
        other.gameObject.SetActive(false);
        Debug.Log("Recorrido terminado");
        
    }

}
