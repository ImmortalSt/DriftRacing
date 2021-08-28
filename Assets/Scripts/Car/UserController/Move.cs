using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour, IMove
{
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _timeUpTo100;
    [SerializeField] private AnimationCurve _accelerationDynamicsNormilize;
    [SerializeField] private float _brakeSensitivity;

    [HideInInspector] public float Speed { get { return _speed; } }
    [HideInInspector] public float MaxSpeed { get { return _maxSpeed; } }


    private Rigidbody _rigibody;
    private float _speedTimeForCurve = 0;
    private float _speed;
    private Vector3 _move;

    private void Start()
    {
        _rigibody = GetComponent<Rigidbody>();
    }

    public void MoveCar(float verticalAxis)
    {

        if (verticalAxis > 0.5f)
            SpeedTimeForCurveChange(0, 1);
        else if (verticalAxis == 0)
            SpeedTimeForCurveChange(0, -1);
        else if (verticalAxis < 0)
            SpeedTimeForCurveChange(_accelerationDynamicsNormilize[0].time, _brakeSensitivity * -1);

        _speed = _accelerationDynamicsNormilize.Evaluate(_speedTimeForCurve / _timeUpTo100) * _maxSpeed;

        _move = transform.forward * _speed;

        _rigibody.velocity = new Vector3(_move.x, _rigibody.velocity.y, _move.z);
    }

    private void SpeedTimeForCurveChange(float minClamp, float coefficient)
    {
        _speedTimeForCurve += Time.deltaTime * coefficient;
        _speedTimeForCurve = ClampCurve(minClamp);
    }

    private float ClampCurve(float minValue)
    {
        return Mathf.Clamp(_speedTimeForCurve, minValue, _timeUpTo100);
    }
}
