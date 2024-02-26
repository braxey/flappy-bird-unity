using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _startGameImage, _gameOverImage, _newHighScore;
    [SerializeField] private TMP_Text _currentScore, _highScore;

    void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }

    void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }

    void Update()
    {
        
    }

    private void GameManagerOnGameStateChanged(GameManager.GameState state)
    {
        // if the game ends, populate the game over scores before activating
        if (state == GameManager.GameState.GameOver) {
            PopulateGameOverMenu();
        }

        // bring up menus depending on game state
        _startGameImage.SetActive(state == GameManager.GameState.StartGame);
        _gameOverImage.SetActive(state == GameManager.GameState.GameOver);
    }

    private void PopulateGameOverMenu()
    {
        _currentScore.text = GameManager.Instance.currentScore.ToString();
        _highScore.text = GameManager.Instance.highScore.ToString();
        _newHighScore.SetActive(GameManager.Instance.newHighScore);
    }
}
