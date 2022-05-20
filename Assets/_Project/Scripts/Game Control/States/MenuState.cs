using UnityEngine;

public class MenuState : IState
{
    public void Execute() { }
    public void Enter() { Debug.Log("Menu State Entered"); }
    public void Exit() { Debug.Log("Menu State Exited"); }
}