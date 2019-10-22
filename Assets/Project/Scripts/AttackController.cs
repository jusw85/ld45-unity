using Jusw85.Common;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Collider2D attackCollider;
    private bool isAttackOnCooldown;
    private bool isAttacking;

    public bool Attack()
    {
        if (isAttacking || isAttackOnCooldown)
        {
            return false;
        }

        isAttacking = true;
        isAttackOnCooldown = true;
        StartCoroutine(CoroutineUtils.DelaySeconds(
            () => { isAttackOnCooldown = false; }, attackCooldown));
        return true;
    }

    public bool IsAttackOnCooldown => isAttackOnCooldown;
    public Collider2D AttackCollider => attackCollider;

    public bool IsAttacking
    {
        get { return isAttacking; }
        set { isAttacking = value; }
    }
}