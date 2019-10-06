using ScriptableObjectArchitecture;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private FloatReference damageAmount = default(FloatReference);

    private void OnTriggerEnter2D(Collider2D other)
    {
        UnitHealth targetHealth = other.transform.root.GetComponentInChildren<UnitHealth>();

        if (targetHealth != null)
        {
            targetHealth.Damage(damageAmount.Value);
        }
    }

    public FloatReference DamageAmount
    {
        get { return damageAmount; }
        set { damageAmount = value; }
    }
}