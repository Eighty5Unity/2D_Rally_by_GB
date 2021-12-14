public class Car : IUpgradableCar
{
    private float _defaultSpeed;

    public float Speed { get; set; }

    public Car(float speed)
    {
        _defaultSpeed = speed;
        Speed = _defaultSpeed;
    }

    public void Restore()
    {
        Speed = _defaultSpeed;
    }
}
