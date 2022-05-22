public class UIMainMenuState : UIStateBase
{
    public void HandlePlayButtonClick()
    {
        GameManager.GetGameState<GamePlayingState>().ResetTimer();
        GameManager.Instance.SwitchState<GamePlayingState>();
    }

    public void HandleSkinsButtonClick()
    {
        UIManager.Instance.SwitchState<UIStoreMenuState>();
    }

    // public void HandleAboutButtonClick()
    // {
    //     throw new NotImplementedException();
    // }
}
