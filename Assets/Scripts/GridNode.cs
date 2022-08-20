using UnityEngine;

public class GridNode : MonoBehaviour
{
    public GridPosition GridPosition;

    private void Start()
    {
        transform.gameObject.GetComponent<Renderer>().material.color = Color.black;
    }
    
    public void OnDrag(GridPosition gridPosition)
    {
        if (gridPosition.X >= 0 && gridPosition.Y >= 0)
        {
            transform.position = new Vector3(gridPosition.X, gridPosition.Y, 0.0f);
            GridPosition = gridPosition;            
        }
    }
}



