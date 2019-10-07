using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateDisable : MonoBehaviour
{
    [SerializeField] private GameObject toDestroy;
    [SerializeField] private GameObject toEnable;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.root.tag.Equals("Player"))
        {
            Destroy(toDestroy);
            toEnable.SetActive(true);
            Destroy(gameObject);
        }
    }
}
