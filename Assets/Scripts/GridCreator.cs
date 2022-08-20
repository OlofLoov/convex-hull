using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridCreator : MonoBehaviour
{
    [SerializeField]
    GameObject EntityPrefab = null;

    [SerializeField]
    public int GridWidth = 40;
    [SerializeField]
    public int GridHeight = 25;

    [SerializeField] 
    public int NoOfActiveNodesAtStart = 10;

    private List<GridNode> gridNodes = new List<GridNode>();

    // Start is called before the first frame update
    void Start()
    {
        CreateGrid();
    }
    
    private void CreateGrid()
    {
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
        
        // clear any existing nodes
        gridNodes = new List<GridNode>();

        for (int i = 0; i < NoOfActiveNodesAtStart; i++)
        {
            var pos = GeneratePosition();
            while ( gridNodes.Where(n => n.GridPosition.X == pos.X && n.GridPosition.Y == pos.Y).Count() > 0)
                pos = GeneratePosition();
            
            var go = Instantiate(EntityPrefab, new Vector3(pos.X,pos.Y, 0.0f), Quaternion.identity);
            go.transform.parent = transform;
            var node = go.GetComponent<GridNode>();
            var gridPosition = new GridPosition(pos.X, pos.Y);
            node.GridPosition = gridPosition;
            gridNodes.Add(node);
        }
    }
    
    private GridPosition GeneratePosition()
    {
        int x = Random.Range(0, GridWidth - 1);
        int y = Random.Range(0, GridHeight - 1);
        return new GridPosition(x, y);
    }
}
