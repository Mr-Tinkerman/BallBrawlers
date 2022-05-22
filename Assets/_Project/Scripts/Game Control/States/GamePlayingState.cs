using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayingState : GameStateBase
{
    public Timer gameTimer = new Timer(30);

    public override void Enter()
    {
        if (!SceneManager.GetSceneByName("Debug Room").isLoaded)
            SceneManager.LoadScene("Debug Room", LoadSceneMode.Additive);

        Time.timeScale = 1;

        gameTimer.OnTimeDepleted += HandleTimeDepleted;
        gameTimer.Resume();
    }

    public override void Exit()
    {
        Time.timeScale = 1;
        gameTimer.Pause();
        gameTimer.OnTimeDepleted -= HandleTimeDepleted;
    }

    public void ResetTimer()
    {
        gameTimer.Reset();
    }

    private void HandleTimeDepleted()
    {
        GameManager.Instance.SwitchState<GameOverState>();
    }
}