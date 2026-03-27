using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugAudio : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void SuccesAudio()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource component not found on DebugAudio GameObject.");
        }
    }
}
