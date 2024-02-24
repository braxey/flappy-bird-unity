using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdCollisionCheck : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the collider belongs to a pipe
        if (other.gameObject.tag == "Pipe") {
            // disable pipe spawning
            HaltPipeSpawning();

            // freeze all pipes
            FreezePipes();

            // freeze bird
            
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
            Destroy(pipe.GetComponent<Rigidbody2D>());
        }
    }
}
