using UnityEngine;

public class BumperHazard : MonoBehaviour
{
    [SerializeField]
    private float pushForce = 5f;

    void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.rigidbody;

        if (rb != null)
        {
            Vector3 targetForce = 
                pushForce * 
                Vector3.Normalize(Vector3.ProjectOnPlane(rb.transform.position - transform.position, Vector3.up));

            rb.AddForce(targetForce, ForceMode.Impulse);
        }
    }
}
