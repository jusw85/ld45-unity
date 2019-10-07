using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;

public class GateDisable : MonoBehaviour
{
    [SerializeField] private GameObject toDestroy;
    [SerializeField] private GameObject toEnable;
    [SerializeField] private GameEvent pickup;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.root.tag.Equals("Player"))
        {
            pickup.Raise();
            Destroy(toDestroy);
            toEnable.SetActive(true);
            Destroy(gameObject);
        }
    }
}
