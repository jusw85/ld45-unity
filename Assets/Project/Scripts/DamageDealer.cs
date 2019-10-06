using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.Events;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private FloatReference damageAmount = default(FloatReference);
    [SerializeField] private UnityEvent dealtDamage;
    [SerializeField] private UnityEvent destroyedOther;

    private void OnTriggerEnter2D(Collider2D other)
    {
        UnitHealth targetHealth = other.transform.root.GetComponentInChildren<UnitHealth>();

        if (targetHealth != null)
        {
            targetHealth.Damage(damageAmount.Value);
            dealtDamage.Invoke();
            if (targetHealth.Health <= 0)
            {
                destroyedOther.Invoke();
            }
        }
    }

    public FloatReference DamageAmount
    {
        get { return damageAmount; }
        set { damageAmount = value; }
    }
}