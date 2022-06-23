public class UIPauseState : UIStateBase
{
    public void HandleBackButtonClick()
    {
        GameManager.Instance.SwitchState<GamePlayingState>();
        UIManager.Instance.SwitchState<UIHUDState>();
    }

    public void HandleResumeButtonClick()
    {
        GameManager.Instance.SwitchState<GamePlayingState>();
        UIManager.Instance.SwitchState<UIHUDState>();
    }

    public void HandleRestartButtonClick()
    {
        // TODO: Reset ball position and regenerate the obstacles

        GameManager.GetGameState<GamePlayingState>().ResetGame();
        GameManager.Instance.SwitchState<GamePlayingState>();
        UIManager.Instance.SwitchState<UIHUDState>();
    }

    public void HandleExitButtonClick()
    {
        UIManager.Instance.SwitchState<UIMainMenuState>();
    }
}
