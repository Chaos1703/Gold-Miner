using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeRenderer : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField] private Transform start;
    private float lineWidth = 0.05f;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = lineWidth;
        lineRenderer.enabled = false;
    }

    public void RenderLine(Vector3 endPosition , bool enableRenderer){
        if(enableRenderer){
            lineRenderer.enabled = true;
            lineRenderer.positionCount = 2;
        }else{
            lineRenderer.positionCount = 0;
            lineRenderer.enabled = false;
        }
        if(lineRenderer.enabled){
            Vector3 temp = start.position;
            temp.z = -10f;
            start.position = temp;
            temp = endPosition;
            temp.z = 0f;
            endPosition = temp;
            lineRenderer.SetPosition(0, start.position);
            lineRenderer.SetPosition(1, endPosition);
        }
    }
}
