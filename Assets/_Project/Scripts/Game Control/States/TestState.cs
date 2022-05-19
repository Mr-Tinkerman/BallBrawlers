using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestState : IState
{
    public void Execute()
    {
        Debug.Log("Test State Executed");
        TestFunc();
    }

    public void Enter()
    {
        Debug.Log("Test State Entered");
    }

    public void Exit()
    {
        Debug.Log("Test State Exited");
    }

    private void TestFunc()
    {
        Debug.Log("Test Func Called");
    }
}
