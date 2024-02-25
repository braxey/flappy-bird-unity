using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdCollisionCheck : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // check if the collider belongs to a pipe
        if (collision.gameObject.tag == "Pipe") {
            // disable pipe spawning
            HaltPipeSpawning();

            // freeze all pipes
            FreezePipes();

            // freeze bird
            FreezeBird();
        }
    }

    void HaltPipeSpawning()
    {
        GameObject pipeSpawner = GameObject.FindWithTag("PipeSpawner");
        if (pipeSpawner != null) {
            Destroy(pipeSpawner.GetComponent<SpawnPipes>());
        }
    }

    void FreezePipes()
    {
        GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe");

        foreach (GameObject pipe in pipes) {
            if (pipe != null) {
                Destroy(pipe.GetComponent<Rigidbody2D>());
            }
        }
    }

    void FreezeBird()
    {
        GameObject bird = GameObject.FindWithTag("Bird");
        if (bird != null) {
            Collider2D collider = bird.transform.GetComponent<Collider2D>();
            collider.enabled = !collider.enabled;

            Rigidbody2D rb = bird.transform.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
}
