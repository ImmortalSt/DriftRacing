public interface IMove
{
    float MaxSpeed { get; }
    float Speed { get; }

    void MoveCar(float verticalAxis);
}