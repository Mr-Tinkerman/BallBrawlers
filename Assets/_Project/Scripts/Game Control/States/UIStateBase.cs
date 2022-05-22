using System;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
public abstract class UIStateBase : MonoBehaviour, IState
{
    Canvas canvas;

    public virtual void Awake()
    {
        canvas = GetComponent<Canvas>();
        UIManager.OnClearUI += HandleClearUI;
    }

    public virtual void OnDestroy()
    {
        UIManager.OnClearUI -= HandleClearUI;
    }

    public virtual void Execute() { }
    public virtual void Enter() { canvas.enabled = true; }
    public virtual void Exit() { canvas.enabled = false; }

    protected void HandleClearUI ()
    {
        canvas.enabled = false;
    }
}
