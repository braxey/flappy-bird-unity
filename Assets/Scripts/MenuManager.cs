using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _startGameImage;

    void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }

    void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void GameManagerOnGameStateChanged(GameManager.GameState state)
    {
        _startGameImage.SetActive(state == GameManager.GameState.StartGame);
    }
}
