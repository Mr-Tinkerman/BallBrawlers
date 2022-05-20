using UnityEngine;

public class GameOverState : IState
{
    public void Execute() { }
    public void Enter() { Debug.Log("Game Over LMFAO!"); }
    public void Exit() { Debug.Log("Wait I was jo- ..."); }
}