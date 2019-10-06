using UnityEngine;

public class GameSettings : MonoBehaviour
{
    [SerializeField] private bool autoSyncTransforms;

    private void Start()
    {
        Physics2D.autoSyncTransforms = autoSyncTransforms;
    }
}