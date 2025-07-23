using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class SimpleRigidBody2DMovement : MonoBehaviour
{
    public float movespeed = 5f;
    private Rigidbody2D rb;

    public float jumpForce = 7f;
    public char jumpDireccion;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    //private bool facingRight = true;
    private bool IsGrounded;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        // Verify if the player is grounded before allowing a jump
        IsGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded && jumpDireccion == 'Y')
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded && jumpDireccion == 'X')
        {
            rb.velocity = new Vector2(rb.velocity.y, jumpForce);
        }

    }
    void FixedUpdate()
    {
        float moveX = 0f;
        //float moveY = 0f;
        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveX = 1f;
        }

        rb.velocity = new Vector2(moveX * movespeed, rb.velocity.y);
    }
}