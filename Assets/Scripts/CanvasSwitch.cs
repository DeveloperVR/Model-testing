using UnityEngine;

public class CanvasSwitch : MonoBehaviour
{
    public GameObject canvas;
    public GameObject button;
    bool timerActive = false;
    float timer = 0;

    public void Update()
    {
        if (timerActive == true)
        {
            TimerIncrease();
        }
        if (timer >= 5)
        {
            DeactivateCanvas();
        }
    }
    public void ActivateCanvas()
    {   
        canvas.SetActive(true);
        button.SetActive(false);
        if (canvas.activeSelf == true && button.activeSelf == false)
        {
            Debug.Log("Canvas is active and button is innactive");
        }
            timerActive = true;
        
    }

    private void DeactivateCanvas()
    {
        canvas.SetActive(false);
        button.SetActive(true);
        if (canvas.activeSelf == false && button.activeSelf == true)
        {
            Debug.Log("Canvas is not active and button is active");
        }
        timerActive = false;
        timer = 0;
    }


    private void TimerIncrease()
    {
        timer = timer + Time.deltaTime;
        Debug.Log("Timer aumentado, y su valor es " + timer);
    }
}
