public interface IRotate
{
    float RudderAngle { get; }
    float MaxAngle { get; }

    void RotateCar(float horintalAxis, float carSpeed, float AngleOffset);
}