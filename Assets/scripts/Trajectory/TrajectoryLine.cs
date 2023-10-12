using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryLine : MonoBehaviour
{
    [SerializeField]
    LineRenderer lineRenderer;
    [SerializeField, Min(3)]
    private int lineSegments = 60;
    [SerializeField, Min(1)]
    private float timeOfFlight = 5;

    public void showTrajectoryLine(Vector3 startPoint, Vector3 startVelocity)
    {
        float timestep = timeOfFlight / lineSegments;
        Vector3[] lineRendererPoints = calculateTrajLine(startPoint, startVelocity, timestep);
        lineRenderer.positionCount = lineSegments;
        lineRenderer.SetPositions(lineRendererPoints);
    }
    private Vector3[] calculateTrajLine(Vector3 startPoint, Vector3 startVelocity, float timestep)
    {
        Vector3[] points = new Vector3[lineSegments];
        points[0] = startPoint;
        for(int i = 1; i < points.Length; i++)
        {
            float timeOffset = timestep * i;
            Vector3 progressBeforeGravity = startVelocity * timeOffset;
            Vector3 gravityOffset = Vector3.up * -0.5f * Physics.gravity.y * timeOffset * timeOffset;
            Vector3 newPoisition = startPoint + progressBeforeGravity - gravityOffset;
            points[i] = newPoisition;
        }
        return points;
    }
}
