using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    public AudioSource musicSource;

    [Header("Músicas")]
    public AudioClip menuMusic;
    public AudioClip phase1Music;
    public AudioClip finalPhaseMusic;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        switch (scene.name)
        {
            case "mainMenu":
            case "Settings":
                PlayMusic(menuMusic);
                break;

            case "Level1":
                PlayMusic(phase1Music);
                break;

            case "FaseFinal":
                PlayMusic(finalPhaseMusic);
                break;
        }
    }

    void PlayMusic(AudioClip clip)
    {
        if (clip == null) return;
        if (musicSource.clip == clip && musicSource.isPlaying) return;

        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }
}
