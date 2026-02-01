using UnityEngine;

public class HunterDamage : MonoBehaviour
{
    public int damage = 10;
    public float attackCooldown = 1f;

    private bool canAttack = true;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!canAttack) return;
        if (!collision.gameObject.CompareTag("Player")) return;

        if (PlayerIsInFront(collision.transform))
        {
            PlayerHealth playerHealth =
                collision.gameObject.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                StartCoroutine(Cooldown());
            }
        }
    }

    bool PlayerIsInFront(Transform player)
    {
        float direction = Mathf.Sign(transform.localScale.x);
        float deltaX = player.position.x - transform.position.x;

        return deltaX * direction > 0;
    }

    System.Collections.IEnumerator Cooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}
