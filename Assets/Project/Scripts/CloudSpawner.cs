using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
	
	public GameObject objectToSpawn;
	public float spawnDelay = 10.0f;
	
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine ("Spawn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	
	IEnumerator Spawn () 
	{
		while (true)
		{
		
		Instantiate (objectToSpawn, transform.position, transform.rotation);
		yield return new WaitForSeconds (10f);
		
		}
	}
}
