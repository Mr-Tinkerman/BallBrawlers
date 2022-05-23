public class UISkinsShopState : UIStateBase
{
    public void HandleBackButtonClick()
    {
        UIManager.Instance.SwitchState<UIMainMenuState>();
        return;

        // UIManager.Instance.SwitchState<UIPauseMenuState>();
    }
}
