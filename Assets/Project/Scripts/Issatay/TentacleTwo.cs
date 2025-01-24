using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleTwo : MonoBehaviour
{
    public int lengh;
    public LineRenderer lineRenderer;
    public Vector3[] segmentPoses;
    private Vector3[] segmentV;

    public Transform targerDirection;
    public float targetDistance;
    public float smoothSpeed;

    public float wiggleSpeed;
    public float wiggleMagnitude;
    public Transform wiggleDir;
    public Transform tileEnd;

    private void Start()
    {
        lineRenderer.positionCount = lengh;
        segmentPoses = new Vector3[lengh];
        segmentV = new Vector3[lengh];

    }
    private void Update()
    {
        wiggleDir.localRotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.time * wiggleSpeed) * wiggleMagnitude);

        segmentPoses[0] = targerDirection.position;
        for(int i = 1; i < segmentPoses.Length; i++)
        {
            // segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i],
            // segmentPoses[i-1] + targerDirection.right * targetDistance,
            // ref segmentV[i],
            // smoothSpeed + i / trailSpeed);

            Vector3 targetPosition = segmentPoses[i-1] + (segmentPoses[i] - segmentPoses[i-1]).normalized * targetDistance;
            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], targetPosition, ref segmentV[i], smoothSpeed);
        }
        //tileEnd.rotation = wiggleDir.localRotation;
        lineRenderer.SetPositions(segmentPoses);
    }
}
