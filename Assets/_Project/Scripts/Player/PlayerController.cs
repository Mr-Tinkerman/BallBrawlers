using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(BallBehaviour))]
public class PlayerController : MonoBehaviour
{
    private BallRollInputActions ballRollInputActions;
    private Vector2 inputMoveSynced;
    private Vector2 inputMove;

    private float lengthCurve;

    BallBehaviour ball;

    private Transform cameraTransform;
    
    void Awake()
    {
        ballRollInputActions = new BallRollInputActions();
        ball = GetComponent<BallBehaviour>();

        cameraTransform = Camera.main.transform;
    }

    void OnEnable()
    {
        ballRollInputActions.Ball.Roll.performed += OnSwipe;
        ballRollInputActions.Ball.Roll.Enable();
    }

    void OnDisable()
    {
        ballRollInputActions.Ball.Roll.Disable();
        ballRollInputActions.Ball.Roll.performed -= OnSwipe;
    }

    void OnSwipe(InputAction.CallbackContext swipeDelta)
    {
        inputMove += swipeDelta.ReadValue<Vector2>();
    }

    Vector3 rollDir;

    void FixedUpdate()
    {
        // Syncing input here prevents input events from changing mid-update call
        // I am also scaling input for a better transition from screen to motion
        inputMoveSynced = inputMove / 25;  // 25 feels the best after testing
        inputMove = Vector2.zero; 

        rollDir = cameraTransform.rotation * new Vector3(inputMoveSynced.x, inputMoveSynced.y, 0);

        ball.Roll(rollDir);

        // Also input event protection
        inputMoveSynced = Vector2.zero;
    }

    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.Cross(rollDir, Vector3.up) * 2);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(inputMoveSynced.x, inputMoveSynced.y, 0).normalized * 2);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + rollDir * 2);
    }
}
