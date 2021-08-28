using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameObjecrtStateGetter))]
public class RenderMap : MonoBehaviour
{
    private GameObjecrtStateGetter _stateGameObjectGetter;
    private float _rotateSize;
    private float _forwardSize;

    private void Awake()
    {
        _stateGameObjectGetter = GetComponent<GameObjecrtStateGetter>();
        _rotateSize = _stateGameObjectGetter.RotateSize;
        _forwardSize = _stateGameObjectGetter.ForwardSize;
    }

    public void ClearCells()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void RenderCells(List<Cell> cells, Vector3 startPosition)
    {

        Vector3 position = startPosition;

        for (int x = 0; x < cells.Count; x++)
        {
            Cell cell = cells[x];
            GameObject body = _stateGameObjectGetter.GetGameObject(cell.CellState);
            Quaternion rotation = Quaternion.Euler(new Vector3(0, GetAngleByDirection(cell.Direction), 0) + body.transform.localRotation.eulerAngles);

            Instantiate(body, position, rotation, transform);
    
            if (cell.CellState == Cell.State.forward)
            {
                position += new Vector3(cell.Direction.x * _forwardSize, 0, cell.Direction.y * _forwardSize);
            }
            else
            {
                position += new Vector3(cell.Direction.x * _rotateSize, 0, cell.Direction.y * _rotateSize);

                Vector2 RoadDirection;

                if (cell.CellState == Cell.State.left)  
                    RoadDirection = cell.Direction.Rotate(-90);
                else
                    RoadDirection = cell.Direction.Rotate(90);

                position += new Vector3(RoadDirection.x * _rotateSize, 0, RoadDirection.y * _rotateSize);
            }
        }
    }

    private float GetAngleByDirection(Vector2Int direction) => 
        Vector3.Angle(Vector3.forward, new Vector3(direction.x, 0, direction.y)) * (direction.x + direction.y);
}
