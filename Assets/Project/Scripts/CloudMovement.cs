using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
	[SerializeField] private float speed;
	private Rigidbody2D myrigidbody2D;
	
    private void Awake()
    {
		myrigidbody2D = GetComponent<Rigidbody2D> ();
		myrigidbody2D.velocity = new Vector2 (speed, myrigidbody2D.velocity.y);
    }
}
