using UnityEngine;

public class HunterHealth : MonoBehaviour
{
    public int life = 30;

    public void TakeDamage(int damage)
    {
        life -= damage;
        Debug.Log("Hunter tomou dano: " + damage);

        if (life <= 0)
        {
            Debug.Log("Hunter morreu");
            Destroy(gameObject);
        }
    }
}
