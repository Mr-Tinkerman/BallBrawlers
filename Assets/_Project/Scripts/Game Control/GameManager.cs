using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public StateMachine stateMachine = new StateMachine();

    public System.Type currentState;

    void Awake()
    {
        #if !UNITY_EDITOR
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        #endif
    }

    void Start()
    {
        Instance.SwitchState<GameMenuState>();
    }

    #if UNITY_EDITOR
    void OnEnable()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
    }
    #endif

    void Update()
    {
        stateMachine.Execute();
    }

    public void SwitchState<T>() where T : GameStateBase, new()
    {
        currentState = typeof(T);
        stateMachine.SwitchState(GetGameState<T>());
    }

    public static T GetGameState<T>() where T : GameStateBase, new()
    {
        return GameStates<T>.state;
    }

    private static class GameStates<T> where T : GameStateBase, new()
    {
        public static readonly T state = new T();
    }
}