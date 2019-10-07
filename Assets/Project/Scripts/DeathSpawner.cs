using UnityEngine;

public class DeathSpawner : MonoBehaviour
{
    public void DeathSpawn()
    {
        GetComponent<ObjectSpawner>().SpawnImmediateWithCallback(go =>
        {
            var scale = go.transform.localScale;
            scale.x = -transform.root.transform.localScale.x;
            go.transform.localScale = scale;
        });
    }
}