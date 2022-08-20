using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DragInteractor : MonoBehaviour
{
    private GameObject _selection = null;
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (_selection != null)
            {
                var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var gridPosition = new GridPosition(pos);
                
                // check if any existing at this grid position, if then just return
                GridNode[] existingNodes = GameObject.FindObjectsOfType<GridNode>();
                if (existingNodes.Where( n => n.GridPosition.X == gridPosition.X && n.GridPosition.Y == gridPosition.Y ).Count() > 0)
                    return;
                
                var node = _selection.GetComponent<GridNode>();
                node.OnDrag(gridPosition);
            }
            else
            {
                if (Physics.Raycast(ray, out hit))
                {
                    var go = hit.collider.gameObject;
                    _selection = go;
                }
            }
        }
        else
        {
            _selection = null;
        }
    }
}