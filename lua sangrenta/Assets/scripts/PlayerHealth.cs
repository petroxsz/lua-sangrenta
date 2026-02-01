using UnityEngine;

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

        
    }
}
