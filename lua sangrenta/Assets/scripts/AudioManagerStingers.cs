using UnityEngine;

public class AudioManagerStingers : MonoBehaviour
{
    public static AudioManagerStingers instance;

    [Header("Stingers")]
    public AudioClip hitClip;
    public AudioClip pickupClip;

    private AudioSource audioSource;

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

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayHit()
    {
        if (hitClip != null)
            audioSource.PlayOneShot(hitClip);
    }

    public void PlayPickup()
    {
        if (pickupClip != null)
            audioSource.PlayOneShot(pickupClip);
    }
}
