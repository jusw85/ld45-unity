using ScriptableObjectArchitecture;
using UnityEngine;

public class PowerupSender : MonoBehaviour
{
    [SerializeField] private PowerupType type;
    [SerializeField] private FloatReference value;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var powerupReceiver = other.GetComponent<PowerupReceiver>();
        if (powerupReceiver != null)
        {
            powerupReceiver.applyPowerup(type, value.Value);
            Destroy(gameObject);
        }
    }
}