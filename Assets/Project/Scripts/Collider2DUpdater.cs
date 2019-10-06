using MyBox;
using UnityEngine;

public class Collider2DUpdater : MonoBehaviour
{
    [MustBeAssigned] [SerializeField] private Collider2DVariable c2D;

    private void Awake()
    {
        c2D.Value = GetComponent<Collider2D>();
    }
}