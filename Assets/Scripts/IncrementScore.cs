using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncrementScore : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D collision)
    {
        // get the object that contains the score
        GameObject scoreObject = GameObject.FindWithTag("Score");
        Score score = scoreObject.GetComponent<Score>();

        // if we passed a score barrier, then increment the score
        if (collision.gameObject.tag == "ScoreBarrier") {
            // make sure the bird isn't already dead
            if (transform.GetComponent<Collider2D>().enabled) {
                score.increment();
            }
        }
    }
}
