using UnityEngine;
using UnityEngine.UI;

public class InputFieldSpriteSwap : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] Sprite activeSprite;

    public void DeactivateInputSprite()
    {
        activeSprite = sprites[1];
        gameObject.GetComponent<Image>().sprite = activeSprite;
    }
    
    public void ActivateInputSprite()
    {
        activeSprite = sprites[0];
        gameObject.GetComponent<Image>().sprite = activeSprite;
    }
}
