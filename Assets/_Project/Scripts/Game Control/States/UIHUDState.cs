using UnityEngine;
using TMPro;

public class UIHUDState : UIStateBase
{
    [SerializeField]
    private TMP_Text _text;

    public void HandlePauseButtonClick()
    {
        GameManager.Instance.SwitchState<GameMenuState>();
        UIManager.Instance.SwitchState<UIPauseState>();
    }
}
