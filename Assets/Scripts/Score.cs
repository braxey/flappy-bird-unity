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
        totalScore = 0;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        // update the UI text with pixel art numbers
        scoreText.text = totalScore.ToString();
    }

    public void increment()
    {
        totalScore += 1;
        UpdateScoreText();
    }
}
