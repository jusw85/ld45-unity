using MyBox;
using ScriptableObjectArchitecture;
using UnityEngine;

public class PositionUpdater : MonoBehaviour
{
    [MustBeAssigned] [SerializeField] private Vector3Variable playerPosition;

    private void LateUpdate()
    {
        playerPosition.Value = transform.position;
    }
}