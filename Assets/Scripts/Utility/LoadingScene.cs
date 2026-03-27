using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private GameObject loadingScreenDesktop;

    public void LoadScene(string SceneId)
    {
        StartCoroutine(LoadSceneAsync(SceneId));
    }

    IEnumerator LoadSceneAsync(string SceneId)
    {

        loadingScreen.SetActive(true);

        loadingScreen.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2.5f;
        loadingScreen.transform.rotation = Quaternion.LookRotation(loadingScreen.transform.position - Camera.main.transform.position);
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneId);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            // Update your loading bar here, e.g.:
            // loadingBar.fillAmount = progress;

            yield return null;
        }

        loadingScreen.SetActive(false);
    }

    // IEnumerator ShowLoadingScreen()
    // { 
    //     loadingScreen.SetActive(true);

    //     loadingScreen.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2.5f;
    //     loadingScreen.transform.rotation = Quaternion.LookRotation(loadingScreen.transform.position - Camera.main.transform.position);
    // }

    IEnumerator LoadDesktopVersionSceneAsync(string SceneId)
    {
        loadingScreenDesktop.SetActive(true);

        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneId);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            // Update your loading bar here, e.g.:
            // loadingBar.fillAmount = progress;

            yield return null;
        }
    }
}
