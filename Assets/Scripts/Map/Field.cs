using System.Collections.Generic;
using UnityEngine;

public class Field
{
    public Dictionary<Vector2Int, Cell> Cells = new Dictionary<Vector2Int, Cell>();
    public List<Cell> Road = new List<Cell>();
    public Vector2Int StartPosion;
}
