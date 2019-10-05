using UnityEngine;

[RequireComponent(typeof(MovementController))]
[RequireComponent(typeof(AttackController))]
[RequireComponent(typeof(PlayerAnimationController))]
public class DrakeController : MonoBehaviour
{
    private AttackController attackController;
    private MovementController movementController;
    private PlayerAnimationController animationController;

    private void Awake()
    {
        attackController = GetComponent<AttackController>();
        movementController = GetComponent<MovementController>();
        animationController = GetComponent<PlayerAnimationController>();
    }

    private void LateUpdate()
    {
        animationController.SetVelocity(movementController.Velocity);
        animationController.SetIsGrounded(movementController.IsGrounded);
        animationController.SetMoveSpeed(movementController.MoveSpeed);
    }

    public void Walk(Vector2 moveInput)
    {
        movementController.Walk(moveInput);
    }

    public void Jump()
    {
        movementController.Jump();
    }

    public void Attack()
    {
        if (movementController.IsGrounded && !attackController.IsAttacking)
        {
            attackController.Attack();
            movementController.StopWalking();
            movementController.IsJumpingEnabled = false;
            movementController.IsWalkingEnabled = false;
            animationController.AnimateAttack(() =>
            {
                movementController.IsJumpingEnabled = true;
                movementController.IsWalkingEnabled = true;
                attackController.IsAttacking = false;
            });
        }
    }
}