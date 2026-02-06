using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    [Header("Vida do Player")]
    public int maxHealth = 100;
    public int currentHealth;

    private bool isDead = false;
    private float lastFadeTime = 1.5f;
    private DamageFlash damageFlash;
    


    void Start()
{
    currentHealth = maxHealth;

    damageFlash = FindFirstObjectByType<DamageFlash>();
}

    // DANO NORMAL
    public void TakeDamage(int damage)
    
{
    if (isDead) return;

    currentHealth -= damage;
    currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

    // CAMERA SHAKE
    CameraFollow cam = Camera.main.GetComponent<CameraFollow>();
    if (cam != null)
        cam.Shake();

    // FLASH VERMELHO
    if (damageFlash != null)
        damageFlash.Flash();

    if (currentHealth <= 0)
    {
        Die(1.2f, 1.5f);
    }

    if (damageFlash != null)
    damageFlash.Flash();

// STINGER DE DANO
if (AudioManagerStingers.instance != null)
    AudioManagerStingers.instance.PlayHit();

if (currentHealth <= 0)
{
    Die(1.2f, 1.5f);
}

}




    public void Heal(int amount)
{
    if (isDead) return;

    currentHealth += amount;
    currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

    Debug.Log("Player curado! Vida atual: " + currentHealth);
}


    // MORTE INSTANTÂNEA (void, queda)
    public void DieInstant()
    {
        if (isDead) return;

        currentHealth = 0;
        Die(0.05f, 0.3f); // tudo rápido
    }

    // CONTROLE CENTRAL DA MORTE
    void Die(float delay, float fadeTime)
    {
        isDead = true;
        lastFadeTime = fadeTime;

        PlayerLives lives = GetComponent<PlayerLives>();

        if (lives != null && lives.UseLife())
        {
            Invoke(nameof(Respawn), delay);
        }
        else
        {
            Invoke(nameof(FadeToGameOver), delay);
        }
    }

    void Respawn()
    {
        isDead = false;
        currentHealth = maxHealth;

        Vector3 respawnPos = Vector3.zero;

        if (CheckpointManager.Instance != null)
        {
            respawnPos = CheckpointManager.Instance.GetCheckpoint();
        }

        transform.position = respawnPos;
    }

    void FadeToGameOver()
    {
        if (FadeAndLoad.Instance != null)
        {
            FadeAndLoad.Instance.FadeToScene("GameOver", lastFadeTime);
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
