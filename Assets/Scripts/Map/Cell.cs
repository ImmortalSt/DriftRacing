using UnityEngine;

public struct Cell
{
    public enum State : uint
    {
        empty,
        left,
        forward,
        right
    }

    public State CellState;
    public Vector2Int Direction
    {
        get
        {
            return _direction;
        }
        set
        {
            if (Mathf.Abs(value.x) + Mathf.Abs(value.y) != 1)
                throw new System.ArgumentException();

            _direction = value;
        }
    }

    private Vector2Int _direction;
}