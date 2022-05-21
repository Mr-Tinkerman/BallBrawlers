using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuState : GameStateBase
{
    public override void Enter()
    {
        if (!SceneManager.GetSceneByName("UI Layer").isLoaded)
            SceneManager.LoadScene("UI Layer", LoadSceneMode.Additive);
    }

    public override void Exit()
    {
        UIManager.Instance.stateMachine.SwitchState(null);
    }
}