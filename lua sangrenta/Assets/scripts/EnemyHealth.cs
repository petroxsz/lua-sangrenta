using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int life = 50;

    public void TakeDamage(int damage)
    {
        life -= damage;
        Debug.Log("Inimigo tomou dano! Vida: " + life);

        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
