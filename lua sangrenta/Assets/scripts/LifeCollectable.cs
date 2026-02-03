using UnityEngine;

public class LifeCollectable : MonoBehaviour
{
    public int lifeAmount = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerLives lives = other.GetComponent<PlayerLives>();

            if (lives != null)
            {
                lives.AddLife(lifeAmount);
            }

            Destroy(gameObject);
        }
    }
}
