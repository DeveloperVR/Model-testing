using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.MixedReality.Toolkit.Experimental.UI;

public class VRKeyboard : MonoBehaviour
{

    private TMP_InputField inputField;

    [SerializeField]
    private float Distance = 0.5f;
    [SerializeField]
    private float VerticalOffset = -0.5f;

    public Transform positionSource;
    // Start is called before the first frame update
    void Start()
    {
        inputField = GetComponent<TMP_InputField>();
        inputField.onSelect.AddListener(OnSelect);
    }

    // Update is called once per frame
    public void OnSelect(string text)
    {
        NonNativeKeyboard.Instance.InputField = inputField;
        NonNativeKeyboard.Instance.PresentKeyboard(inputField.text); 

        Vector3 Direction = positionSource.forward;
        Direction.y = 0;
        Direction.Normalize();

        Vector3 targetPosition = positionSource.position + Direction * Distance + Vector3.up * VerticalOffset;

        NonNativeKeyboard.Instance.RepositionKeyboard(targetPosition);
    }
}
