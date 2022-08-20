using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ConvexHullLineRenderer : MonoBehaviour
{
    private LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        var nodes = FindObjectsOfType<GridNode>().ToList();
        var ch = new ConvexHull(nodes);
        var convexHull = ch.JarvisMarch();
        
        lineRenderer.positionCount = convexHull.Count();
        for (int i = 0; i < convexHull.Count(); i++)
        {
            lineRenderer.SetPosition(i, convexHull[i].transform.position);
        }
    }
}
