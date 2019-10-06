using MyBox;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.Events;

public class UnitHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private UnityEvent unitDamaged;
    [SerializeField] private UnityEvent unitDied;
    [ReadOnly] private float health;

    private void Awake()
    {
        health = maxHealth;
    }

    public void Damage(float damage)
    {
        health -= damage;
        Debug.Log(health);
        if (health <= 0)
        {
            unitDied.Invoke();
            unitDamaged.Invoke();
        }
    }

    public void Heal(float heal)
    {
        health = Mathf.Clamp(health + heal, 0, maxHealth);
    }

    public float MaxHealth => maxHealth;

    public float Health => health;

    //TODO: Refactor this
    //Idea: unitDamaged event triggers FloatUpdater
    //FloatUpdater members: method delegate that returns int, alwaysUpdate bool, SO object
    //if alwaysUpdate, LateUpdate invokes delegate
    //otherwise, method for triggering refresh

    [SerializeField] private FloatReference playerHealth;
    [SerializeField] private FloatReference playerMaxHealth;

    private void LateUpdate()
    {
        playerHealth.Value = health;
        playerMaxHealth.Value = maxHealth;
    }
}