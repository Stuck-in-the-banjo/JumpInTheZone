using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float smashForce = 10;
	void Start () {
		
	}
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = new Vector3(rb.velocity.x, -smashForce);
        }
	}
}
