using System;
using UnityEngine;

public class WheelRotater : MonoBehaviour
{
    [SerializeField] private bool _canRotate;

    private static readonly float s_wheelRadius = 0.5f;

    private Vector3 _newWheelRotation;

    public void UpdateWheel(float speed, float angle = 0)
    {
        speed = Mathf.Clamp(speed, 0, 10);
        
        if(_canRotate)
        {
            _newWheelRotation.y = angle;
        }

        _newWheelRotation.x += speed / s_wheelRadius;

        transform.localEulerAngles = _newWheelRotation;
        
    }
}
