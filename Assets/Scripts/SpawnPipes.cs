using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPipes : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnRate = 5f;

    private float nextSpawnTime = 0f;

    void Update()
    {
        if (Time.time >= nextSpawnTime) {
            // spawn a new pipe
            GameObject newPipe = Instantiate(pipePrefab, transform.position, Quaternion.identity);
            nextSpawnTime = Time.time + spawnRate;
        }
    }
}
