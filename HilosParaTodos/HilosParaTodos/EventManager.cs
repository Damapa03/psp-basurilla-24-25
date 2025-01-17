namespace HilosParaTodos;

public class EventManager<T>
{
    private event Action<T> OnEvent;

    public void Subscribe(Action<T> handler)
    {
        OnEvent += handler;
    }

    public void Unsubscribe(Action<T> handler)
    {
        OnEvent -= handler;
    }

    public void Trigger(T args)
    {
        OnEvent?.Invoke(args);
    }
}