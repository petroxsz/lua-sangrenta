using UnityEngine;

public class HeartPickup : MonoBehaviour
{
    public int healAmount = 20;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Coração coletado");

            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.Heal(healAmount);

                if (AudioManagerStingers.instance != null)
                {
                    Debug.Log("Chamando PlayPickup");
                    AudioManagerStingers.instance.PlayPickup();
                }

                Destroy(gameObject);
            }
        }
    }
}
