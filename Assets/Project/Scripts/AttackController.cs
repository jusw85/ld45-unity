using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
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

    public bool IsAttacking
    {
        get { return isAttacking; }
        set { isAttacking = value; }
    }
}