using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartClick : MonoBehaviour
{
    public void Restart()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.StartGame);
    }
}
