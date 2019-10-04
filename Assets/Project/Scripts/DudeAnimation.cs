using UnityEngine;

public class DudeAnimation : MonoBehaviour {

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Awake() {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetIsFacingRight(bool isFacingRight) {
        spriteRenderer.flipX = !isFacingRight;
    }

    public void SetWalking() {
        animator.SetTrigger("walking");
    }

    public void SetJumping() {
        animator.SetTrigger("jumping");
    }

    public void SetIdle() {
        animator.SetTrigger("idle");
    }

}
