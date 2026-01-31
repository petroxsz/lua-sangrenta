using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Attack Settings")]
    public Transform attackPoint;
    public float attackRange = 0.6f;
    public int attackDamage = 25;
    public LayerMask enemyLayer;
    public float attackCooldown = 0.5f;

    private float nextAttackTime = 0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + attackCooldown;
        }
    }

    void Attack()
    {
        
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(
            attackPoint.position,
            attackRange,
            enemyLayer
        );

        foreach (Collider2D enemy in hitEnemies)
        {
            
            enemy.SendMessage("TakeDamage", attackDamage, SendMessageOptions.DontRequireReceiver);
        }

        Debug.Log("Ataque do lobisomem!");
    }

    
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
