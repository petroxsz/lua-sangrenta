using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [Header("Referências")]
    public Slider slider;
    public PlayerHealth playerHealth;

    void Start()
    {
        if (playerHealth != null)
        {
            slider.maxValue = playerHealth.maxHealth;
            slider.value = playerHealth.currentHealth;
        }
    }

    void Update()
    {
        if (playerHealth != null)
        {
            slider.value = playerHealth.currentHealth;
        }
    }
}
