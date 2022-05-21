using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
