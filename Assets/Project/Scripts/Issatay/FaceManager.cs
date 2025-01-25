using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceManager : MonoBehaviour
{
    public Transform target;   // The object to follow
    public float smoothSpeed = 0.125f; // Smoothing factor (lower = smoother)
    public Vector3 offset;     // Offset from the target position

    void FixedUpdate()
    {
        if (target == null) return;

        Vector3 targetPosition = target.position + offset;

        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);

        transform.position = smoothPosition;
    }
}
