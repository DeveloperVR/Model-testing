using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enterbutton : MonoBehaviour
{

    [SerializeField] private GameObject self;
    [SerializeField] private GameObject menu;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Button enterButton;
    public NameTag nameTag;
    public void CaptureText()
    {

        if (inputField == null)
        {
            Debug.LogError("InputField no asignado");
            return;
        }

        string textoIngresado = inputField.text;
        Debug.Log("Texto ingresado: " + textoIngresado);
        nameTag.SetText(textoIngresado);

        self.gameObject.SetActive(false);

        menu.SetActive(true);
    }
}
