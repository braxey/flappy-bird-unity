using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeInitialization : MonoBehaviour
{
    public const int TOP_PIPE_CHILD_INDEX = 0;
    public const int BOTTOM_PIPE_CHILD_INDEX = 1;
    public const int SCORE_BARRIER_CHILD_INDEX = 2;

    private const float PIPE_X_VELOCITY = -2f;
    private const float PIPE_Y_SCALE = 5f;

    void Start()
    {
        float yPositionOfPipes = Random.Range(-2.7f, 2.7f);
        transform.position = transform.position + new Vector3(0, yPositionOfPipes, 0);

        Transform bottomPipe = transform.GetChild(BOTTOM_PIPE_CHILD_INDEX);
        Transform topPipe = transform.GetChild(TOP_PIPE_CHILD_INDEX);

        Rigidbody2D bottomPipeRb = bottomPipe.GetComponent<Rigidbody2D>();
        Rigidbody2D topPipeRb = topPipe.GetComponent<Rigidbody2D>();

        bottomPipeRb.velocity = new Vector2(PIPE_X_VELOCITY, 0f);
        topPipeRb.velocity = new Vector2(PIPE_X_VELOCITY, 0f);
    }
}
