using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRenderBehaviour : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public Transform targetTransform;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.startColor = Color.blue;
        lineRenderer.endColor = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, targetTransform.position);
    }
}
