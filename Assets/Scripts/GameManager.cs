using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState state;
    public static event Action<GameState> OnGameStateChanged;

    [SerializeField] private GameObject _bird, _pipeSpawner, _score;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateGameState(GameState.StartGame);
    }

    public void UpdateGameState(GameState newState)
    {
        state = newState;

        switch (newState) {
            case GameState.StartGame:
                HandleStartGame();
                break;
            case GameState.GameStarted:
                HandleGameStarted();
                break;
            case GameState.GameOver:
                HandleGameOver();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState);
    }

    public enum GameState {
        StartGame,
        GameStarted,
        GameOver
    }

    public void HandleStartGame()
    {
        // make the bird hover
        _bird.GetComponent<Rigidbody2D>().gravityScale = 0;
        _bird.transform.rotation = Quaternion.Euler(0, 0, 0);
        _bird.GetComponent<BirdOrientation>().enabled = false;

        // disable the pipe spawner
        _pipeSpawner.SetActive(false);

        // disable the score system
        _score.SetActive(false);
    }

    public void HandleGameStarted()
    {
        // enable the bird movements
        _bird.GetComponent<Rigidbody2D>().gravityScale = 1;
        _bird.GetComponent<BirdOrientation>().enabled = true;

        // enable the pipe spawner
        _pipeSpawner.SetActive(true);

        // enable the score system
        _score.SetActive(true);
    }

    public void HandleGameOver()
    {

    }
}
