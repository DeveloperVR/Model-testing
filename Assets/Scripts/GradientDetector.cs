using UnityEngine;

public class GradientDetector : MonoBehaviour
{
    public GameObject GradientLine;


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.name);
        if (other.CompareTag("Player") || other.CompareTag("VRPlayer"))
        {
            Debug.Log("Player entered gradient detector");
            if (GradientLine != null)
            {
                GradientLine.SetActive(true);
            }

        }

    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger exited by: " + other.name);
        if (other.CompareTag("Player") || other.CompareTag("VRPlayer"))
        {
            Debug.Log("Player exited gradient detector");
            if (GradientLine != null)
            {
                GradientLine.SetActive(false);
            }
        }
    }

    public void SetLine(GameObject line)
    {
        GradientLine = line;
    }


}
