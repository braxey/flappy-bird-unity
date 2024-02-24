using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncrementScore : MonoBehaviour
{
    void OnCollisionExit2d(Collision2D other)
    {
        Debug.LogError("hello");
        GameObject scoreObject = GameObject.FindWithTag("Score");
        Score score = scoreObject.GetComponent<Score>();

        // listen for pipes colliding with the collector
        if (other.gameObject.tag == "Bird") {
            score.increment();
            Debug.LogError(score.getScore());
        }
    }
}
