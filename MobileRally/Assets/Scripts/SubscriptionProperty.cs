using System;

public class SubscriptionProperty<T> : ISubscriptionProperty<T>
{
    private Action<T> _onValueChange;
    private T _value;

    public T Value
    {
        get => _value;
        set
        {
            _value = value;
            _onValueChange?.Invoke(_value);
        }
    }

    public SubscriptionProperty(T value)
    {
        Value = value;
    }

    public SubscriptionProperty()
    {

    }

    public void SubscribeOnChange(Action<T> action)
    {
        _onValueChange += action;
    }

    public void UnSubscribe(Action<T> action)
    {
        _onValueChange -= action;
    }
}
