using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPipes : MonoBehaviour
{
    private Transform siblingPipe;

    void Start()
    {
        siblingPipe = transform.parent.gameObject.transform.GetChild(PipeInitialization.TOP_PIPE_CHILD_INDEX);
    }

    void Update()
    {
        transform.position = new Vector2(siblingPipe.transform.position.x, transform.position.y);
    }
}
