using System;
using UnityEngine;

// TODO: find some way to hook callbacks on the spawned object
public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private bool enableOnStart;
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private float initialSpawnDelay;
    [SerializeField] private bool spawnContinuously;
    [SerializeField] private float spawnInterval;

    private void Start()
    {
        if (enableOnStart)
        {
            if (spawnContinuously)
            {
                DoSpawnContinuously();
            }
            else
            {
                if (spawnInterval <= 0)
                {
                    DoSpawnImmediate();
                }
                else
                {
                    DoSpawnOneShot();
                }
            }
        }
    }

    public void DoSpawnContinuously()
    {
        StartCoroutine(
            CoroutineUtils.Repeat(Spawn, initialSpawnDelay, spawnInterval));
    }

    /**
     * Waits 1 frame
     */
    public void DoSpawnOneShot()
    {
        StartCoroutine(
            CoroutineUtils.Chain(this,
                CoroutineUtils.WaitForSeconds(initialSpawnDelay),
                CoroutineUtils.Do(Spawn)
            ));
    }

    public void DoSpawnImmediate()
    {
        Spawn();
    }

    // TODO: FIX THIS SHIT
    public void SpawnImmediateWithCallback(Action<GameObject> callback)
    {
        callback(Instantiate(objectToSpawn, transform.position, transform.rotation));
    }

    private void Spawn()
    {
        Instantiate(objectToSpawn, transform.position, transform.rotation);
    }
}