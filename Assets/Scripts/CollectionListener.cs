using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionListener : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        // listen for pipes colliding with the collector
        if (other.gameObject.tag == "Pipe") {
            Destroy(other.gameObject.transform.parent.gameObject);
        }
    }
}
