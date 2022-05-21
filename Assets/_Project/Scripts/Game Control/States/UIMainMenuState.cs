using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainMenuState : UIStateBase
{
    public void HandlePlayButtonClick()
    {
        GameManager.Instance.SwitchState<GamePlayingState>();
    }

    public void HandleStoreButtonClick()
    {
        UIManager.Instance.SwitchState<UIStoreMenuState>();
    }

    // public void HandleAboutButtonClick()
    // {
    //     throw new NotImplementedException();
    // }
}
