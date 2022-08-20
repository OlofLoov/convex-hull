using UnityEngine;

public struct GridPosition
{
    public int X;
    public int Y;

    public GridPosition(int x, int y)
    {
        X = x;
        Y = y;
    }

    public GridPosition(Vector3 vector)
    {
        var x = Mathf.RoundToInt(vector.x);
        var y = Mathf.RoundToInt(vector.y);
        X = x;
        Y = y;
    }
}