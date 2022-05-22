using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayingState : GameStateBase
{
    public Timer gameTimer = new Timer(30);

    public override void Enter()
    {
        if (!SceneManager.GetSceneByName("Debug Room").isLoaded)
            SceneManager.LoadScene("Debug Room", LoadSceneMode.Additive);

        gameTimer.OnTimeDepleted += OnGameTimerEnd;
        gameTimer.Start();
    }

    public override void Exit()
    {
        gameTimer.OnTimeDepleted -= OnGameTimerEnd;
    }

    private void OnGameTimerEnd()
    {
        GameManager.Instance.SwitchState<GameOverState>();
    }
}