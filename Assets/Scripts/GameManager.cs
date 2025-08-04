using UnityEngine;
using System;
using Enums;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //public enum GameState { Menu, Game, LevelComplete, GameOver}

    private GameState gameState;

    public static Action<GameState> onGameStateChanged;
    
    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void SetGameState(GameState gameState)
    { 
        this.gameState = gameState;
        onGameStateChanged?.Invoke(gameState);  //onGameStateChanged adinda bir event (olay) varsa onu tetikler

        Debug.Log("Game State Changed to: " + gameState);
    }

    public bool IsGameState()
    {
        return gameState == GameState.Game;
    }
}
