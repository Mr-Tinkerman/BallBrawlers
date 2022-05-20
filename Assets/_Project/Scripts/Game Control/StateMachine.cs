using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

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

        currentState = state;
        currentState.Enter();
    }

    public void Execute()
    {
        currentState.Execute();
    }
}

public interface IState { void Execute(); void Enter(); void Exit(); }