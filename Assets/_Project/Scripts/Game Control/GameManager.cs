using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public StateMachine stateMachine = new StateMachine();

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

        SwitchState<MenuState>();
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

    public void SwitchState<T>() where T : IState, new()
    {
        T temp = new T();

        stateMachine.SwitchState(GetGameState<T>());
    }

    public static T GetGameState<T>() where T : IState, new()
    {
        return GameStates<T>.state;
    }

    private static class GameStates<T> where T : IState, new()
    {
        public static readonly T state = new T();
    }
}