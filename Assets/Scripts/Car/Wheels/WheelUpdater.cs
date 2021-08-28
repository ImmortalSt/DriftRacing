using UnityEngine;

public class WheelUpdater : MonoBehaviour
{
    private WheelRotater[] _wheels;

    private void Start()
    {
        _wheels = GetComponentsInChildren<WheelRotater>();
    }

    public void UpdateWheel(float carSpeed, float rudderAngle)
    {
        foreach (var wheel in _wheels)
        {
            wheel.UpdateWheel(carSpeed, rudderAngle);
        }
    }
}
