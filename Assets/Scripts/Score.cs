using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text scoreText;
    private int totalScore;

    void Start()
    {
        resetScore();
    }

    void UpdateScoreText()
    {
        scoreText.text = totalScore.ToString();
    }

    public void increment()
    {
        totalScore += 1;
        UpdateScoreText();
    }

    public int GetScore()
    {
        return totalScore;
    }

    public void resetScore()
    {
        totalScore = 0;
        UpdateScoreText();
    }
}
