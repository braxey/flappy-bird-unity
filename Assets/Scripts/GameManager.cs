using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState state;
    public static event Action<GameState> OnGameStateChanged;
    public int currentScore, highScore;
    public bool newHighScore;

    [SerializeField] private GameObject _bird, _pipeSpawner;
    [SerializeField] private TMP_Text _scoreText;

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
        // destory all pipes
        GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe");

        foreach (GameObject pipe in pipes) {
            if (pipe != null) {
                Destroy(pipe.transform.parent.gameObject);
            }
        }

        // make the bird hover
        _bird.GetComponent<Rigidbody2D>().gravityScale = 0;
        _bird.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);;
        _bird.transform.position = new Vector2(0, 0);
        _bird.transform.rotation = Quaternion.Euler(0, 0, 0);
        _bird.transform.GetComponent<Collider2D>().enabled = true;
        _bird.GetComponent<BirdOrientation>().enabled = false;

        // disable the pipe spawner
        _pipeSpawner.SetActive(false);

        // disable the score system
        _scoreText.enabled = false;
    }

    public void HandleGameStarted()
    {
        // enable the bird movements
        _bird.GetComponent<Rigidbody2D>().gravityScale = 1;
        _bird.GetComponent<BirdOrientation>().enabled = true;

        // enable the pipe spawner
        _pipeSpawner.SetActive(true);

        // enable the score system
        _scoreText.enabled = true;
    }

    public void HandleGameOver()
    {
        // save the current score and high score
        Score scoreScript = GameObject.FindWithTag("Score").GetComponent<Score>();
        currentScore = scoreScript.GetScore();
        newHighScore = false;

        highScore = PlayerPrefs.GetInt("highScore");
        if (currentScore > highScore) {
            highScore = currentScore;
            newHighScore = true;
            PlayerPrefs.SetInt("highScore", highScore);
        }

        // reset the current score
        scoreScript.resetScore();

        // hide the score
        _scoreText.enabled = false;
    }
}
