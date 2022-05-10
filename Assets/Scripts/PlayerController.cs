using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(BallMovement))]
public class PlayerController : MonoBehaviour
{
    private BallRollInputActions ballRollInputActions;
    private Vector2 inputMoveSynced;
    private Vector2 inputMove;

    BallMovement ballMovement;
    
    void Awake()
    {
        ballRollInputActions = new BallRollInputActions();
        ballMovement = GetComponent<BallMovement>();
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

        ballMovement.Roll(inputMoveSynced);

        // Also input event protection
        inputMoveSynced = Vector2.zero;
    }
}
