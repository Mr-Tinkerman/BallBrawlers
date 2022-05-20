using UnityEngine;

public class GamePlayingState : GameStateBase
{
    public Timer gameTimer = new Timer(30);

    public override void Enter()
    {
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