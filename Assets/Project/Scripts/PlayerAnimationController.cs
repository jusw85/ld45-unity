using UnityEngine;

[RequireComponent(typeof(MovementController))]
public class PlayerAnimationController : MonoBehaviour
{
    private MovementController movementController;
    private Rigidbody2D rb2d;
    private Animator animator;

    private void Awake()
    {
        movementController = GetComponent<MovementController>();
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void LateUpdate()
    {
        animator.SetFloat("Speed", Mathf.Abs(movementController.MoveInput.x));
        animator.SetFloat("vSpeed", rb2d.velocity.y);
        animator.SetBool("Ground", movementController.IsGrounded);
        animator.SetFloat("WalkSpeedMultiplier", movementController.MoveSpeed * 0.25f);
    }
}