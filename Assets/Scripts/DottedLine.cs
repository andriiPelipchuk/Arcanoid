using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DottedLine : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float dotSpacing = 0.2f; 
    public float dotSize = 0.05f; 

    public Vector3 ActivateDottedLine()
    {
        lineRenderer.enabled = true;
        lineRenderer.startWidth = dotSize;
        lineRenderer.endWidth = dotSize;
        lineRenderer.positionCount = 2;

        lineRenderer.startColor = Color.white;
        lineRenderer.endColor = Color.white;

        Vector3[] positions = new Vector3[2];
        positions[0] = transform.position;
        positions[1] = SetDirection();
        positions[1].z = transform.position.z;

        float distance = Vector3.Distance(positions[0], positions[1]);
        int dotsCount = Mathf.FloorToInt(distance / dotSpacing);


        lineRenderer.positionCount = dotsCount;

        CreateLine(positions, dotsCount);

        return positions[1] - positions[0];
    }

    public void DeactivateDottedLine()
    {
        lineRenderer.enabled = false;
    }

    private void CreateLine(Vector3[] positions, int dotsCount)
    {
        for (int i = 0; i < dotsCount; i++)
        {
            Vector3 dotPosition = Vector3.Lerp(positions[0], positions[1], (float)i / (float)(dotsCount - 1));
            lineRenderer.SetPosition(i, dotPosition);
        }
    }

    private Vector3 SetDirection()
    {
        Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mouseScreenPosition - (Vector2)transform.position).normalized;
        transform.up = direction;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        if (hit.collider != null)
        {
            return hit.point;
        }

        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
