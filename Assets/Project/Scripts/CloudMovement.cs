﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float speed;

	private Rigidbody2D myrigidbody2D;

	// Start is called before the first frame update
    void Start()
    {
        
		myrigidbody2D = GetComponent<Rigidbody2D> ();

    }

    // Update is called once per frame
    void Update()
    {
        myrigidbody2D.velocity = new Vector2 (speed, myrigidbody2D.velocity.y);

    }
}
