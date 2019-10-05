using UnityEngine;

public class MovementController : MonoBehaviour
{
//    public UnityEvent onPlayerMove;
    // movement type as enum

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb2d;
    private Vector2 moveInput;
    private bool toJump;
    private bool isGrounded;
    private bool isFacingRight = true;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        if (isGrounded)
        {
            toJump = true;
        }
    }
    
    public void Move(Vector2 moveInput)
    {
        this.moveInput = moveInput;
        if (moveInput.x != 0)
        {
            SetIsFacingRight(moveInput.x > 0);
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        var newVelocity = rb2d.velocity;
        newVelocity.x = moveInput.x * moveSpeed;
        if (toJump)
        {
            toJump = false;
            newVelocity.y = jumpHeight;
        }

        rb2d.velocity = newVelocity;
    }

    private void SetIsFacingRight(bool isFacingRight)
    {
        if (this.isFacingRight ^ isFacingRight)
        {
            var scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }

        this.isFacingRight = isFacingRight;
    }

    public float MoveSpeed
    {
        get { return moveSpeed; }
        set { moveSpeed = value; }
    }

    public float JumpHeight
    {
        get { return jumpHeight; }
        set { jumpHeight = value; }
    }

    public Vector2 MoveInput => moveInput;

    public bool IsGrounded => isGrounded;
}