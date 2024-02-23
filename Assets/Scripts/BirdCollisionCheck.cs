using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdCollisionCheck : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the collider belongs to a pipe
        if (other.gameObject.tag == "Pipe") {
            // Perform actions when the bird collides with a pipe
            Debug.LogError("Bird collided with a pipe!");

            // Add your code to handle the collision, such as game over logic or score update
        }
    }
}
