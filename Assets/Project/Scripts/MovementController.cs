using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpHeight;
    
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask groundLayer;
    
    [SerializeField] private Transform wallCheck;
    [SerializeField] private float wallCheckRadius;
    [SerializeField] private LayerMask wallLayer;
    
    [SerializeField] private Transform edgeCheck;
    [SerializeField] private float edgeCheckRadius;

    private Rigidbody2D rb2d;
    private Vector2 moveInput;
    private bool toJump;
    private bool isGrounded;
    private bool isFacingRight = true;

    private bool isWalkingEnabled = true;
    private bool isJumpingEnabled = true;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public bool Jump()
    {
        if (!IsJumpingEnabled)
        {
            return false;
        }

        if (isGrounded)
        {
            toJump = true;
        }

        return true;
    }

    public bool Walk(Vector2 moveInput)
    {
        if (!IsWalkingEnabled)
        {
            return false;
        }

        this.moveInput = moveInput;
        if (moveInput.x != 0)
        {
            SetIsFacingRight(moveInput.x > 0);
        }

        return true;
    }

    public void StopWalking()
    {
        moveInput.x = 0;
        var newVelocity = rb2d.velocity;
        newVelocity.x = 0;
        rb2d.velocity = newVelocity;
    }

    public bool IsAtWall()
    {
        return Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, wallLayer);
    }
    
    public bool IsAtEdge()
    {
        return !Physics2D.OverlapCircle(edgeCheck.position, edgeCheckRadius, groundLayer);
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

    public bool IsFacingRight => isFacingRight;
    public Vector2 MoveInput => moveInput;
    public bool IsGrounded => isGrounded;
    public Vector2 Velocity => rb2d.velocity;

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

    public bool IsWalkingEnabled
    {
        get { return isWalkingEnabled; }
        set { isWalkingEnabled = value; }
    }

    public bool IsJumpingEnabled
    {
        get { return isJumpingEnabled; }
        set { isJumpingEnabled = value; }
    }
}