using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyHazard : MonoBehaviour
{
    [SerializeField]
    private float stickyDrag = 0.5f;

    // Slows player down
    void OnTriggerEnter(Collider col)
    {
        Rigidbody rb = col.attachedRigidbody;

        if (rb != null)
        {
            rb.drag = stickyDrag;
        }
    }

    // Resets player's max speed
    void OnTriggerExit(Collider col)
    {
        Rigidbody rb = col.attachedRigidbody;

        if (rb != null)
        {
            rb.drag = 0;
        }
    }
}
