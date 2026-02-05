using UnityEngine;

public class TimeCoin : MonoBehaviour
{
    public float timeValue = 5f; // segundos que adiciona

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TimeManager tm = FindAnyObjectByType<TimeManager>();


            if (tm != null)
            {
                tm.AddTime(timeValue);
            }

            Destroy(gameObject);
        }
    }
}
