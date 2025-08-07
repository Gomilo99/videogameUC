using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class SimpleRigidBody2DMovement : MonoBehaviour
{
    private static readonly int IsJumpingid = Animator.StringToHash(name: "IsJumping");
    private static readonly int SpeedX = Animator.StringToHash(name: "SpeedX");
    [Header("Rigidbody2D Component")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Parameters")]
    [SerializeField] private bool facingRight = false;
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private float moveSpeed = 5f;

    [Header("References")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;

    [SerializeField] private Animator animator;
    //private bool facingRight = true;
    private bool IsGrounded;
    private bool IsJumping;
    private int moveX;

    void Start()
    {
        if(rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
            if (rb == null)
            {
                Debug.LogError("Rigidbody2D component not found on this GameObject.");
            }
        }
    }
    void Update()
    {
        // Verify if the player is grounded before allowing a jump
        IsGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            IsJumping = true;
            animator.SetBool(IsJumpingid, IsJumping);
        }
        if (IsJumping && rb.velocity.y <= 0)
        {
            IsJumping = false;
            animator.SetBool(IsJumpingid, false);
        }

        //Detectar flip
        moveX = (int)Input.GetAxisRaw("Horizontal");
        if (moveX > 0 && !facingRight)
            Flip();
        else if (moveX < 0 && facingRight)
            Flip();
    }
    void FixedUpdate()
    {
        //float moveY = 0f;
        /*
        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveX = 1f;
        }
        */
        moveX = (int)Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);
        animator.SetInteger(SpeedX, moveX);
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}