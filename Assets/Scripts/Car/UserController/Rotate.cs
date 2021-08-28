using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour, IRotate
{
    [HideInInspector] public float RudderAngle { get { return _angle; } }
    [HideInInspector] public float MaxAngle { get { return _maxAngle; } }


    [SerializeField] private float _maxAngle;
    [SerializeField] private AnimationCurve _rotateScale;

    private float _angle = 0;

    public void RotateCar(float horintalAxis, float carSpeed, float AngleOffset)
    {

        _angle = Utills.Map(horintalAxis, -1, 1, _maxAngle * -1, _maxAngle);

        transform.localEulerAngles += new Vector3(0, _angle - AngleOffset, 0) * Time.deltaTime * _rotateScale.Evaluate(carSpeed);
    }
}