using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("Vida do Lobisomem")]
    public int maxHealth = 100;
    public int currentHealth;

    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        Debug.Log("Vida inicial: " + currentHealth);
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // Feedback visual
        DamageFlash flash = FindObjectOfType<DamageFlash>();
        if (flash != null) flash.Flash();

        CameraShake shake = FindObjectOfType<CameraShake>();
        if (shake != null) shake.Shake();

        Debug.Log("Lobisomem tomou dano! Vida atual: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (isDead) return;

        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log("Lobisomem se curou! Vida atual: " + currentHealth);
    }

    void Die()
    {
        isDead = true;
        Debug.Log("O Lobisomem morreu!");

        PlayerLives lives = GetComponent<PlayerLives>();

        if (lives != null && lives.UseLife())
        {
            // Ainda tem vidas → respawn
            Invoke(nameof(Respawn), 1.2f);
        }
        else
        {
            // Sem vidas → Game Over com fade
            Invoke(nameof(FadeToGameOver), 1.2f);
        }
    }

    void Respawn()
    {
        isDead = false;
        currentHealth = maxHealth;

        Debug.Log("Respawn realizado!");

        // Respawn temporário (depois entra checkpoint)
        transform.position = Vector3.zero;
    }

    void FadeToGameOver()
    {
        if (FadeAndLoad.Instance != null)
        {
            FadeAndLoad.Instance.FadeToScene("GameOver");
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
