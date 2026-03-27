using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NameTag : MonoBehaviour
{

    public TextMeshPro textMesh;

    public void SetText(string text)
    {
        GameObject textObject = new GameObject("UsernameText");
        textObject.transform.SetParent(this.transform);
        textMesh = textObject.AddComponent<TextMeshPro>();

        textMesh.alignment = TextAlignmentOptions.Center;
        textMesh.fontSize = 4;
        textMesh.color = Color.black;
        textMesh.transform.position = this.transform.position + Vector3.up * 3f;
        textMesh.text = text;
    }
}
