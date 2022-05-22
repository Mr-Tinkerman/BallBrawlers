public class UIStoreMenuState : UIStateBase
{
    public void HandleBackButtonClick()
    {
        if (GameManager.Instance.currentState == typeof(GameMenuState))
        {
            UIManager.Instance.SwitchState<UIMainMenuState>();
            return;
        }

        // UIManager.Instance.SwitchState<UIPauseMenuState>();
    }
}
