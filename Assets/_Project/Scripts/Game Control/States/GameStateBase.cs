public abstract class GameStateBase : IState
{
    public virtual void Execute() { }
    public virtual void Enter() { }
    public virtual void Exit() { }
}
