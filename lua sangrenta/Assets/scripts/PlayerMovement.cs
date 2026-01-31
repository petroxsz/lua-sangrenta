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

    private float moveInput;
    private float currentSpeed;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
        moveInput = Input.GetAxisRaw("Horizontal");

        
        currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );

        
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            float finalJumpForce = jumpForce;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                finalJumpForce *= runJumpMultiplier;
            }

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, finalJumpForce);
        }

        
        if (moveInput > 0)
            sprite.flipX = false;
        else if (moveInput < 0)
            sprite.flipX = true;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * currentSpeed, rb.linearVelocity.y);
    }

    
    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
