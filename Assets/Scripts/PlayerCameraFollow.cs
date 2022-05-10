using UnityEngine;

public class PlayerCameraFollow : MonoBehaviour
{
    [Range(0, 1)]
    public float followSpeed = 0.9f;
    [Range(0, 1)]
    public float lookSpeed = 0.9f;

    public float maxDistance = 7;
    public float minDistance = 4;
    public float desiredDistance = 5;
    public float relativeHeight = 3;

    private Transform player;
    private Vector3 targetPosition;
    private Quaternion targetRotation;

    private Vector3 notUp = new Vector3(1, 0, 1);

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        targetPosition = Vector3.ProjectOnPlane(transform.position - player.position, Vector3.up);
        targetPosition = targetPosition.normalized * (Mathf.Clamp(Mathf.Lerp(targetPosition.magnitude, desiredDistance, followSpeed), minDistance, maxDistance));
        targetPosition += player.position;

        targetPosition.y = player.position.y + relativeHeight;
        targetRotation = Quaternion.LookRotation(Vector3.Normalize(player.position - targetPosition), Vector3.up);
        targetRotation = Quaternion.Lerp(transform.rotation, targetRotation, lookSpeed);

        transform.position = targetPosition;
        transform.rotation = targetRotation;
    }
}
