using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    [Header("Sistema de Vidas")]
    public int maxLives = 3;
    public int currentLives;

    void Start()
    {
        currentLives = maxLives;
        Debug.Log("Vidas iniciais: " + currentLives);
    }

    // Ganha uma vida (moeda)
    public void AddLife(int amount = 1)
    {
        currentLives += amount;
        currentLives = Mathf.Clamp(currentLives, 0, maxLives);

        Debug.Log("Vida ganha! Vidas atuais: " + currentLives);
    }

    // Usa uma vida (quando morre)
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
