using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteSwap : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private UnityEngine.UI.Image button;

    public void SwapSprite(int index)
    {
        if (index < 0 || index >= sprites.Length)
        {
            Debug.LogError("Index out of bounds for sprite array.");
            return;
        }
        if (button.sprite == sprites[0])
        {
            button.sprite = sprites[index];
            return;
        }
        button.sprite = sprites[0];
        

    }
}
