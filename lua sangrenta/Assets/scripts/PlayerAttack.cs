using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int attackDamage = 10;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Ataque do lobisomem");
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") &&
            Input.GetKeyDown(KeyCode.Space))
        {
            HunterHealth hunterHealth =
                collision.gameObject.GetComponent<HunterHealth>();

            if (hunterHealth != null)
            {
                hunterHealth.TakeDamage(attackDamage);
            }
        }
    }
}
