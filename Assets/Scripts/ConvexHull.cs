
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ConvexHull
{
    private List<GridNode> nodes;
    private GridNode startNode;
    
    public ConvexHull(List<GridNode> nodes)
    {
        this.nodes = nodes;
    }
    
    /*
     *Starting from a leftmost point of the data set, we keep the points in the convex hull
     * by anti-clockwise rotation. From a current point, we can choose the next point by checking
     * the orientations of those points from the current point.
     * When the angle is largest, the point is chosen. After completing all points,
     * when the next point is the start point, stop the algorithm.
     */

    public List<GridNode> JarvisMarch()
    {
        var convexHull = new List<GridNode>();
        // select start node, node most left
        var startNode = nodes.OrderBy(n => n.GridPosition.X).First();
        GridNode currentNode = startNode;
        
        while (true) 
        {
            GridNode candidateNode = null;
            convexHull.Add(currentNode);
            candidateNode = nodes[0];
            
            for(var j = 1; j < nodes.Count; j++)
            {
                if (candidateNode == currentNode || ccw(currentNode, candidateNode, nodes[j]) < 0)
                    candidateNode = nodes[j];
            }
            
            currentNode = candidateNode;
            if (candidateNode == convexHull[0]) // break if back at beginning
                break;
        }
        
        // adding start node again for rendering purposes
        convexHull.Add(startNode);

        return convexHull;
    }
    
    private static float ccw(GridNode p, GridNode q, GridNode r)
    {
        return Mathf.Sign((q.GridPosition.X - p.GridPosition.X) * 
            (r.GridPosition.Y - p.GridPosition.Y) - (r.GridPosition.X - p.GridPosition.X) *
            (q.GridPosition.Y - p.GridPosition.Y));
    }
}
