using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;
    public GameState gameState;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void OnEnable()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
    }

    public enum GameState
    {
        MainMenu,
        Shop,
        Equip,
        Settings,
        Playing,
        Paused,
        GameOver
    }

    public void GameOver()
    {
        gameState = GameState.GameOver;
        Debug.Log("User has died.  If app still running, switch state.");
    }
}