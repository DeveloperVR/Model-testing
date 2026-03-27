using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairActivation : MonoBehaviour
{
    private bool IsStandardActive = false;
    private GameObject StandardCrosshair;
    void Start()
    {
        StandardCrosshair = GameObject.Find("Crosshair");
    }

    // Update is called once per frame
    void Update()
    {
        if (IsStandardActive == true)
        {
            StandardCrosshair.SetActive(true);
        }
        else
        {
            StandardCrosshair.SetActive(false);
        }

    }

    public void SetIsStandardActive(bool value)
    { 
        IsStandardActive = value;
        
    }
}
