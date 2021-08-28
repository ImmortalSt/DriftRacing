using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FieldGenerator : IFieldGenerator
{
    private readonly int _enumCellLenght = System.Enum.GetValues(typeof(Cell.State)).Length;

    private Field _field;

    public Field GenerateField(int maxRoadLenght)
    {
        _field = new Field();

        _field.StartPosion = new Vector2Int(0, 0);
        Cell StartCell = GetRandomStartCell();
        AddCell(_field.StartPosion, StartCell);

        Vector2Int directionRoad = StartCell.Direction;
        Vector2Int positionRoad = _field.StartPosion;

        for (int i = 0; i < maxRoadLenght + 1; i++)
        {
                

            Cell cell = new Cell();

            cell.CellState = GetRandomRoadState(new Cell.State[] { Cell.State.empty });
            cell.Direction = directionRoad;

            positionRoad += directionRoad;
            directionRoad = directionRoad.Rotate(GetAngleByState(cell.CellState));

            if (_field.Cells.ContainsKey(positionRoad) == false)
            {
                AddCell(positionRoad, cell);
            }
            else
            {
                directionRoad = _field.Cells[_field.Cells.Keys.Last()].Direction;
                RemoveLastCell();
                positionRoad = _field.Cells.Keys.Last();
            }
        }

        RemoveLastCell();
        return _field;
    }
    private Cell GetRandomStartCell()
    {
        Cell StartCell = new Cell();
        StartCell.CellState = Cell.State.forward;

        do
        {
            StartCell.Direction = GetRandomDirection();
        } while (CheckAround(_field.StartPosion + StartCell.Direction) != 0);

        return StartCell;
    }
    private void RemoveLastCell()
    {
        _field.Cells.Remove(_field.Cells.Keys.Last());
        _field.Road.RemoveLast();
    }
    private void AddCell(Vector2Int positionLastRoad, Cell cell)
    {
        _field.Cells.Add(positionLastRoad, cell);
        _field.Road.Add(cell);
    }
    private float GetAngleByState(Cell.State state)
    {
        return (((int)state) - 2) * 90;
    }
    private Cell.State GetRandomRoadState(Cell.State[] without)
    {
        Cell.State result;
        uint[] withoutInt = System.Array.ConvertAll(without, value => (uint)value);

        do
        {
            result = (Cell.State)UnityEngine.Random.Range(0, _enumCellLenght);
        } while (((uint)result).Contains(withoutInt));

        return result;
    }
    private int CheckAround(Vector2Int position)
    {
        int result = 0;
        position -= new Vector2Int(1, 1);

        for (int i = 0; i < 9; i++)
        {
            try
            {
                if (_field.Cells.ContainsKey(new Vector2Int(position.x + i % 3, position.y + i / 3)))
                    result++;
            } catch(System.IndexOutOfRangeException)
            {
                result++;
            }
        }

        return result;
    }
    private Vector2Int GetRandomDirection()
    {
        int orientation = Random.Range(0, 3);
        Vector2Int result = new Vector2Int();

        switch (orientation) {
            case 0:
                result = Vector2Int.up;
                break;
            case 1:
                result = Vector2Int.right;
                break;
            case 2:
                result = Vector2Int.down;
                break;
            case 3:
                result = Vector2Int.left;
                break;

        }
        return result;
    }
}
