using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    IState currentState;

    public void SwitchState(IState state)
    {
        if (currentState != null)
            currentState.Exit();

        currentState = state;
        currentState.Enter();
    }

    public void Execute()
    {
        if (currentState != null)
            currentState.Execute();
    }
}

public interface IState { void Execute(); void Enter(); void Exit(); }