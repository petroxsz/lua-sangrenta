using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int attackDamage = 10;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void Attack()
    {
        Debug.Log("Ataque do lobisomem");
        animator.SetTrigger("atacou");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
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
