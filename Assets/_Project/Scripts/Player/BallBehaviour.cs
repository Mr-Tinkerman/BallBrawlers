using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class BallBehaviour : MonoBehaviour
{
    public float rollTorqueFactor = 1;
    public float maxVelocity = 30;

    private Vector3 relativeUp = Vector3.up;

    private ContactPoint[] contactPoints = new ContactPoint[0];

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = maxVelocity;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position - relativeUp * 2);
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -relativeUp, out hit, 2f))
        {
            relativeUp = hit.normal;
        }
        else
        {
            relativeUp = Vector3.up;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag != "Environment")
            return;

        if (collision.contactCount > contactPoints.Length)
            contactPoints = new ContactPoint[collision.contactCount];

        collision.GetContacts(contactPoints);

        Vector3 avgDir = Vector3.zero;

        for (int i = 0; i < collision.contactCount; ++i)
        {
            avgDir += contactPoints[i].normal.normalized;
        }

        avgDir = Vector3.Normalize(avgDir / collision.contactCount);
        relativeUp = avgDir;
    }

#if UNITY_EDITOR
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Roll(Vector3.forward * 100);
        }
    }
#endif

    public void Roll(Vector3 rollVector)
    {
        Vector3 rollAxis = Vector3.Cross(relativeUp, rollVector) * rollVector.magnitude;
        rb.AddTorque(rollAxis * rollTorqueFactor);
    }
}