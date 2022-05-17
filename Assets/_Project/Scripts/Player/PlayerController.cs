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
    }

    void OnSwipe(InputAction.CallbackContext ctx)
    {
        inputMove += ctx.ReadValue<Vector2>();
    }

    Vector3 rollDir;

    void FixedUpdate()
    {
        // Prevents input events from changing mid-update call
        lengthCurve = inputMove.magnitude / 25;// * inputMove.magnitude * inputMove.magnitude / 100;
        inputMoveSynced = inputMove.normalized * lengthCurve;
        inputMove = Vector2.zero;

        Debug.Log(inputMove);

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
