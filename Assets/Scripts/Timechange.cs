using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timechange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.S))
        {
            Time.timeScale = 0.5f; // Cambia la velocidad del tiempo a la mitad
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Time.timeScale = 1f; // Cambia la velocidad del tiempo a la normal
        }
    }
}
