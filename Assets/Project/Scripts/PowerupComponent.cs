using ScriptableObjectArchitecture;
using UnityEngine;

public class PowerupComponent : MonoBehaviour
{
    [SerializeField] private Powerup powerup;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            powerup.Apply(other.gameObject);
            Destroy(gameObject);
        }
    }
}