using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AsyncSceneLoaderWithFade : MonoBehaviour
{
    public string sceneName; // The name of the scene to load
    public float fadeTime = 1f; // The time it takes to fade in and out
    public Image fadeImage; // The image used for fading

    private Scene originalScene;
    private AsyncOperation asyncOperation;

    private void Start()
    {
        originalScene = SceneManager.GetActiveScene();
        StartCoroutine(LoadSceneAsync());
    }

    private IEnumerator LoadSceneAsync()
    {
        // Fade out
        fadeImage.gameObject.SetActive(true);
        fadeImage.color = Color.clear;
        float timer = 0f;
        while (timer < fadeTime)
        {
            timer += Time.deltaTime;
            fadeImage.color = Color.Lerp(Color.clear, Color.black, timer / fadeTime);
            yield return null;
        }

        // Load scene asynchronously
        asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        while (!asyncOperation.isDone)
        {
            yield return null;
        }

        // Fade in
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
        timer = 0f;
        while (timer < fadeTime)
        {
            timer += Time.deltaTime;
            fadeImage.color = Color.Lerp(Color.black, Color.clear, timer / fadeTime);
            yield return null;
        }
        fadeImage.gameObject.SetActive(false);

        // Unload original scene
        SceneManager.UnloadSceneAsync(originalScene);
    }
}
