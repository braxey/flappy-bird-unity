using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdJump : MonoBehaviour
{
    private float jumpForce = 5f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && transform.position.y < 6) {
            Jump();
        }

        if (transform.position.y < -3.5) {
            transform.position = new Vector2(0, -3.5f);
            // transform.rotation = Quaternion.Euler(0, 0, 0);
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
