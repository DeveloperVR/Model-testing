using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MuteAudio : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioListener audioListener;
    public UnityEvent muting;
    public void Mute()
    {
        muting.Invoke();
    }

    public void muteListener()
    {
        audioListener.enabled = false;
    }

    public void UnmuteListener()
    {
        audioListener.enabled = true;
    }
}
