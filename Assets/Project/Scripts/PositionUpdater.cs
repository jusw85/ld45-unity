using MyBox;
using ScriptableObjectArchitecture;
using UnityEngine;

public class PositionUpdater : MonoBehaviour
{
    [MustBeAssigned] [SerializeField] private Vector3Variable position;

    private void LateUpdate()
    {
        position.Value = transform.position;
    }
}