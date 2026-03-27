using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PixelCalculator : MonoBehaviour
{
    void Start()
    {
        RectTransform rt = GetComponent<RectTransform>();
        Canvas canvas = GetComponentInParent<Canvas>();
        float scaleFactor = canvas.scaleFactor;
        Vector2 pixelSize = rt.rect.size * scaleFactor;

        Debug.Log(gameObject.name + " Size in Pixels: " + pixelSize);
    }
}
