using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string sceneName; // Nombre de la escena a la que quieres cambiar

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
