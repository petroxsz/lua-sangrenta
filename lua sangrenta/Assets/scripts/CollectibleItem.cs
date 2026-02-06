using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    [Header("Configuração")]
    public AudioClip pickupSound;

    protected virtual void OnCollect(GameObject player)
    {
        // Aqui cada item faz sua lógica
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnCollect(other.gameObject);

            if (AudioManagerStingers.instance != null && pickupSound != null)
                AudioManagerStingers.instance.GetComponent<AudioSource>()
                    .PlayOneShot(pickupSound);

            Destroy(gameObject);
        }
    }
}
