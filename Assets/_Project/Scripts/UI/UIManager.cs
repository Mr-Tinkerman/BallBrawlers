using System;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private List<Canvas> _UILayers;

    public static event Action OnClearUI = delegate { };

    public StateMachine stateMachine = new StateMachine();

    public static UIManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
    }

    void Start()
    {
        SwitchState<UIMainMenuState>();
    }

    public static void ClearUI()
    {
        OnClearUI?.Invoke();
    }

    public void SwitchState<T>() where T : UIStateBase, new()
    {
        IState state = GetUIState<T>();

        if (state == null)
            Debug.LogWarningFormat
            (
                "A UI state of {0} could not be found!  Defaulting to NullState",
                typeof(T)
            );

        stateMachine.SwitchState(state);
    }

    public static IState GetUIState<T>() where T : UIStateBase, new()
    {
        return UIStates<T>.state;
    }

    private static class UIStates<T> where T : UIStateBase, new()
    {
        public static readonly T state = FindObjectOfType<T>();
    }
}