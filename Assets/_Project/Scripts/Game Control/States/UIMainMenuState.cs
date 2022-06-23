public class UIMainMenuState : UIStateBase
{
    public void HandlePlayButtonClick()
    {
        GameManager.GetGameState<GamePlayingState>().ResetGame();
        GameManager.Instance.SwitchState<GamePlayingState>();
        
        UIManager.Instance.SwitchState<UIHUDState>();
    }

    public void HandleSkinsButtonClick()
    {
        UIManager.Instance.SwitchState<UISkinsShopState>();
    }

    // public void HandleAboutButtonClick()
    // {
    //     throw new NotImplementedException();
    // }
}
