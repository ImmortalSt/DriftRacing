using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameObjecrtStateGetter : MonoBehaviour
{
    public float RotateSize;
    public float ForwardSize;

    public GameObject GetGameObject(Cell.State state)
    {
        if (_dictionary.Count == 0)
            _dictionary = _units.ToDictionary(key => key.CellState, value => value.Body);

        return _dictionary[state];
    }

    [SerializeField] private Unit[] _units;

    private Dictionary<Cell.State, GameObject> _dictionary = new Dictionary<Cell.State, GameObject>();

    [Serializable]
    private class Unit
    {
        public Cell.State CellState;
        public GameObject Body;
    }

    private void Awake()
    {
        if (_units.Length != Enum.GetValues(typeof(Cell.State)).Length - 1)
            throw new ArgumentException();

        for (int i = 0; i < _units.Length; i++)
        {
            for (int j = 0; j < _units.Length; j++)
            {
                if (i == j) continue;

                if (_units[i].CellState == _units[j].CellState)
                    throw new ArgumentException("Duplicates State");
            }
        }

        for (int i = 0; i < _units.Length; i++)
        {
            if (_units[i].Body == null)
            {
                throw new ArgumentNullException("Null Body");
            }
        }
    }
}
