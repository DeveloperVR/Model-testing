using UnityEngine;

public class CaptureFunction : MonoBehaviour
{
    public string input { get; private set; }
    [SerializeField] GameObject InputMenu;
    

    public void textedCaptured(string text)
    {
        input = text;
        Debug.Log("Function captured successfully!");
        Debug.Log("The text captured was: " + input);
    }

    
}
