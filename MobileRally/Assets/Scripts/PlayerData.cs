//Модель хранения данных об игроке и текущем состоянии игры
public class PlayerData
{
    public SubscriptionProperty<GameStateEnum> GameState { get; }
    public Car Car { get; private set; }

    public PlayerData()
    {
        Car = new Car(5f);
        GameState = new SubscriptionProperty<GameStateEnum>();
    }
}
