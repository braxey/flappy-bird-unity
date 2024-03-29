using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdJump : MonoBehaviour
{
    private float jumpForce = 5f;

    void Update()
    {
        // check for space bar and that the bird is below the allowed height
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && transform.position.y < 6) {
            // make sure the bird is not dead
            if (GameManager.Instance.state != GameManager.GameState.GameOver) {
                Jump();
            }
        }

        if (transform.position.y < -3.5) {
            transform.position = new Vector2(0, -3.5f);
        }

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb.velocity.y < -30f) {
            rb.velocity = new Vector2(0f, -30f);
            rb.angularVelocity = 0f;
        }
    }

    private void Jump()
    {
        // apply force to make the bird jump
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (rb != null) {
            rb.velocity = new Vector2(0f, jumpForce);
        }

        if (GameManager.Instance.state == GameManager.GameState.StartGame) {
            GameManager.Instance.UpdateGameState(GameManager.GameState.GameStarted);
        }
    }
}
