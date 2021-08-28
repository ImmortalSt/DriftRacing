using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private CalculateSize _mapSize;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _yCoef;
    [SerializeField] private float _xCoef;

    private CalculateSize.Range[] _sizeRoads;

    public void UpdateCameraPosition()
    {
        StartCoroutine(UpdatePosition());
    }

    private IEnumerator UpdatePosition()
    {
        yield return null;
        _mapSize.Init();
        _sizeRoads = _mapSize.GetSize();
        transform.position = _offset + new Vector3(
                (_sizeRoads[0].MaxValue + _sizeRoads[0].MinValue) / 2,
                (_sizeRoads[0].MaxValue - _sizeRoads[0].MinValue) * _xCoef + (_sizeRoads[2].MaxValue - _sizeRoads[2].MinValue) * _yCoef,
                (_sizeRoads[2].MaxValue + _sizeRoads[2].MinValue) / 2);
    }

    private void OnDrawGizmos()
    {
        if (_sizeRoads != null)
        {
            Gizmos.DrawWireCube(new Vector3(
                (_sizeRoads[0].MaxValue + _sizeRoads[0].MinValue) / 2,
                0,
                (_sizeRoads[2].MaxValue + _sizeRoads[2].MinValue) / 2),
                new Vector3(_sizeRoads[0].MaxValue - _sizeRoads[0].MinValue, 0, _sizeRoads[2].MaxValue - _sizeRoads[2].MinValue));
        }
    }
}
