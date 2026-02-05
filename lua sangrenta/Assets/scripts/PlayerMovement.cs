using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float walkSpeed = 5f;
    public float runSpeed = 8f;

    [Header("Jump")]
    public float jumpForce = 12f;
    public float runJumpMultiplier = 1.3f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;

    private float moveInput;
    private float currentSpeed;
    private bool isGrounded;
    private bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (isDead) return;

        // Movimento horizontal
        moveInput = Input.GetAxisRaw("Horizontal");

        // Corrida
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        currentSpeed = isRunning ? runSpeed : walkSpeed;

        // Checagem de chão
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );

        // ---------------- ANIMAÇÕES ----------------

        // Andando / Idle
        anim.SetBool("andando", moveInput != 0);
        anim.SetBool("correndo", isRunning && moveInput != 0);

        // Pulo
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded)
        {
            float finalJumpForce = jumpForce;

            if (isRunning)
                finalJumpForce *= runJumpMultiplier;

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, finalJumpForce);
            anim.SetTrigger("pulou");
        }

        // Ataque
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("atacou");
        }

        // Flip do sprite
        if (moveInput > 0)
            sprite.flipX = false;
        else if (moveInput < 0)
            sprite.flipX = true;
    }

    void FixedUpdate()
    {
        if (isDead) return;

        rb.linearVelocity = new Vector2(moveInput * currentSpeed, rb.linearVelocity.y);
    }

    // ☠️ MORTE (chame isso de outro script quando perder todas as vidas)
    public void Die()
    {
        if (isDead) return;

        isDead = true;
        rb.linearVelocity = Vector2.zero;
        anim.SetTrigger("morreu");
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
