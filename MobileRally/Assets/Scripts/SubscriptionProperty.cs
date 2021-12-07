using System;

public class SubscriptionProperty<T> : ISubscriptionProperty<T>
{
    private Action<T> _onValueChange;

    public T Value { get; set; }

    public SubscriptionProperty()
    {
    }

    public SubscriptionProperty(T value)
    {
        Value = value;
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
