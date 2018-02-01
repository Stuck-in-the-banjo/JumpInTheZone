using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour {

    public float jumpForce = 10f;
    public float platformSides_force = 5;

    public Vector3 positionA;
    public Vector3 positionB;
    public float min_distance = 1.0f;
    public float speed = 1.0f;

    private Vector3 direction;

    void Update()
    {
        if ((transform.position - positionA).magnitude <= min_distance)
            direction = (positionB - transform.position).normalized;
        else if ((transform.position - positionB).magnitude <= min_distance)
            direction = (positionA - transform.position).normalized;

        transform.position += direction * Time.deltaTime * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.relativeVelocity.y <= 0)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                //Set Y velocity
                Vector2 vel = rb.velocity;
                vel.y = jumpForce;
                rb.velocity = vel;

                //Platform Sides force
                Transform platform = collision.collider.GetComponent<Transform>();
                Vector3 platform_size = GetComponent<SpriteRenderer>().sprite.bounds.size;

                float player_pos = collision.gameObject.GetComponent<Transform>().position.x;
                float platform_pos = transform.position.x;
                if (player_pos > platform_pos + (platform_size.x/3.5))
                {
                    rb.velocity = new Vector3(platformSides_force, rb.velocity.y, 0);
                }
                if (player_pos < platform_pos - (platform_size.x / 3.5))
                {
                    rb.velocity = new Vector3(-platformSides_force, rb.velocity.y, 0);
                }
            }
        }  
    }
}
