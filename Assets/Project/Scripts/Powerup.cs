using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] private IntVariable target;
    [SerializeField] private IntReference value;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            if (target != null && value != null)
            {
                target.Value += value.Value;
            }
            Destroy(gameObject);
        }
    }
}
