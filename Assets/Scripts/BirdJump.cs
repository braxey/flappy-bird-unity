using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdJump : MonoBehaviour
{
    private float jumpForce = 5f;

    void Update()
    {
        // check for space bar and that the bird is below the allowed height
        if (Input.GetKeyDown(KeyCode.Space) && transform.position.y < 6) {

            // make sure the bird is not dead
            if (transform.GetComponent<Collider2D>().enabled) {
                Jump();
            }
        }

        if (transform.position.y < -3.5) {
            transform.position = new Vector2(0, -3.5f);
        }
    }

    private void Jump()
    {
        // apply force to make the bird jump
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (rb != null) {
            rb.velocity = new Vector2(0f, jumpForce);
        }
    }
}
