using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallMovement : MonoBehaviour
{
    public float rollTorqueFactor = 1;
    public float maxVelocity = 30;

    private Rigidbody rb;
    private Transform mainCamera;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main.transform;
    }

    public void Roll(Vector2 rollVector)
    {
        rb.maxAngularVelocity = maxVelocity;
        rb.AddTorque(rollTorqueFactor * (mainCamera.right * rollVector.y + Vector3.ProjectOnPlane(mainCamera.forward, Vector3.up) * rollVector.x));
    }
}
