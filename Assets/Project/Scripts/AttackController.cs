using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    private bool isAttackOnCooldown;

    public void Attack()
    {
        if (!isAttackOnCooldown)
        {
            isAttackOnCooldown = true;
            StartCoroutine(CoroutineUtils.DelaySeconds(
                () => { isAttackOnCooldown = false; }, attackCooldown));
        }
    }

    public bool IsAttackOnCooldown => isAttackOnCooldown;
}