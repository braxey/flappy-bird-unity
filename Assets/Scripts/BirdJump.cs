using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputListener : MonoBehaviour
{
    private float jump_force = 5f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }
    }

    private void Jump()
    {
        // Apply force to make the bird jump
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (rb != null) {
            rb.velocity = new Vector2(0f, jump_force);
        }
    }
}
