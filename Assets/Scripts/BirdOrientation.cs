using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdOrientation : MonoBehaviour
{   
    private Rigidbody2D birdRb;

    void Start()
    {
        birdRb = transform.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (birdRb != null) {
            if (birdRb.velocity.y > -0.5) {
                transform.rotation = Quaternion.Euler(0, 0, 25);
            } else if (birdRb.velocity.y > -0.75) {
                transform.rotation = Quaternion.Euler(0, 0, 13);
            } else if (birdRb.velocity.y > -1) {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            } else if (birdRb.velocity.y > -1.25) {
                transform.rotation = Quaternion.Euler(0, 0, -13);
            }else {
                transform.rotation = Quaternion.Euler(0, 0, -25);
            }
        }
    }
}
