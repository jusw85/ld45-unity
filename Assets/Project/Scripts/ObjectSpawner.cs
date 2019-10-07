using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private float spawnDelay = 10.0f;

    private void Start()
    {
        StartCoroutine(CoroutineUtils.Repeat(
            () => { Instantiate(objectToSpawn, transform.position, transform.rotation); },
            0, spawnDelay));
    }
}