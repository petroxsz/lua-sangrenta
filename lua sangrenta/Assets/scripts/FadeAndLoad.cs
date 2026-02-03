using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class FadeAndLoad : MonoBehaviour
{
    public static FadeAndLoad Instance;

    public Image fadeImage;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void FadeToScene(string sceneName, float duration)
    {
        StopAllCoroutines();
        StartCoroutine(FadeOutAndLoad(sceneName, duration));
    }

    IEnumerator FadeOutAndLoad(string sceneName, float duration)
    {
        float t = 0f;
        Color color = fadeImage.color;

        while (t < duration)
        {
            t += Time.unscaledDeltaTime;
            color.a = Mathf.Lerp(0f, 1f, t / duration);
            fadeImage.color = color;
            yield return null;
        }

        SceneManager.LoadScene(sceneName);
    }
}
