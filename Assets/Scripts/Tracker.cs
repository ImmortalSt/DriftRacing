using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _height;

    private Vector3 _newPosition;

    private void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, _height, transform.localPosition.z);

        transform.LookAt(_target);
    }
}
