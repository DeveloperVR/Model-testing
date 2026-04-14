using UnityEngine;

public class CanvasSwitch : MonoBehaviour
{
    public GameObject canvas1;
    int timer = 0;

    public void ActivateCanvas()
    {   
        Debug.Log("Canvas activated");
        canvas1.SetActive(true); 
        while (timer < 50)
        {
            timer++;
        }
        if (timer >= 50)
        {
            Debug.Log("Canvas deactivated");
            canvas1.SetActive(false);
            timer = 0;
        }
    }
}
