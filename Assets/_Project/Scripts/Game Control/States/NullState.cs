// This state EXCLUSIVELY exists as a placeholder
// for the State Machines initialized state and
// absolutely no functionality whatsoever.

public class NullState : IState
{
    public void Execute() { }
    public void Enter() { }
    public void Exit() { }
}