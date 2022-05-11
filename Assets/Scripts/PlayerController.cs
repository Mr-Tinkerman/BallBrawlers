using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(BallBehaviour))]
public class PlayerController : MonoBehaviour
{
    private BallRollInputActions ballRollInputActions;
    private Vector2 inputMoveSynced;
    private Vector2 inputMove;

    BallBehaviour ball;
    
    void Awake()
    {
        ballRollInputActions = new BallRollInputActions();
        ball = GetComponent<BallBehaviour>();
    }

    void OnEnable()
    {
        ballRollInputActions.Ball.Roll.performed += OnSwipe;
        ballRollInputActions.Ball.Roll.Enable();
    }

    void OnDisable()
    {
        ballRollInputActions.Ball.Roll.Disable();
    }

    void OnSwipe(InputAction.CallbackContext ctx)
    {
        inputMove += ctx.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        // Prevents input events from changing mid-update call
        inputMoveSynced = inputMove * inputMove * inputMove / 100;
        inputMove = Vector2.zero;

        ball.Roll(inputMoveSynced);

        // Also input event protection
        inputMoveSynced = Vector2.zero;
    }
}
