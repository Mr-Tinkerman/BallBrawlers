using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    [SerializeField]
    private float speedBoost = 15f;

    // Boosts player in their velocity direction
    void OnTriggerEnter(Collider col)
    {
        Rigidbody rb = col.attachedRigidbody;

        if (rb != null)
        {
            rb.AddForce(rb.velocity.normalized * speedBoost, ForceMode.Impulse);
        }
    }
}
