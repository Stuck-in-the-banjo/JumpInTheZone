using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightWallScript : MonoBehaviour {

    public float force = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();

        Vector2 knockbackVelocity = new Vector2((transform.position.x - rb.transform.position.x) * force, rb.velocity.y);
        rb.velocity = knockbackVelocity;
    }
}
