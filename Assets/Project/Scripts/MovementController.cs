using UnityEngine;

public class MovementController : MonoBehaviour
{
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

    public Vector2 Velocity => rb2d.velocity;
}