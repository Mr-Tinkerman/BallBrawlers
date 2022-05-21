using UnityEngine;

[RequireComponent(typeof(Canvas))]
public abstract class UIStateBase : MonoBehaviour, IState
{
    Canvas canvas;

    public virtual void Awake()
    {
        canvas = GetComponent<Canvas>();
    }

    public virtual void Execute() { }
    public virtual void Enter() { canvas.enabled = true; }
    public virtual void Exit()  { canvas.enabled = false; }
}
