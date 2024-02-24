using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int totalScore;

    void Start()
    {
        totalScore = 0;
    }

    public void increment()
    {
        totalScore += 1;
    }

    public int getScore()
    {
        return totalScore;
    }
}
