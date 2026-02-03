using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    [Header("Sistema de Vidas")]
    public int maxLives = 6;
    public int currentLives = 0;

    private static bool initialized = false; // garante que inicializa apenas uma vez

    void Start()
    {
        if (!initialized)
        {
            // Se currentLives estiver zerado, inicia com maxLives
            if (currentLives <= 0)
                currentLives = maxLives;

            initialized = true;
        }

        Debug.Log("Vidas iniciais: " + currentLives);
    }

    // Ganha vida (coletável)
    public void AddLife(int amount = 1)
    {
        currentLives += amount;
        currentLives = Mathf.Clamp(currentLives, 0, maxLives);

        Debug.Log("Vida ganha! Vidas atuais: " + currentLives);
    }

    // Usa vida (morte)
    public bool UseLife()
    {
        if (currentLives > 0)
        {
            currentLives--;
            Debug.Log("Vida usada! Vidas restantes: " + currentLives);
            return true;
        }

        Debug.Log("Sem vidas restantes!");
        return false;
    }
}
