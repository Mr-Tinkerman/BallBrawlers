public class StateMachine
{
    IState currentState;

    public StateMachine()
    {
        currentState = new NullState();
    }

    public void SwitchState(IState state)
    {
        currentState.Exit();

        currentState = (state == null) ? new NullState() : state;
        currentState.Enter();
    }

    public void Execute()
    {
        currentState.Execute();
    }
}

public interface IState { void Execute(); void Enter(); void Exit(); }