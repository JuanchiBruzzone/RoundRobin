namespace RoundRobin;

public class RoundRobinScheduler<T>
{
    private readonly List<T> items;
    private int currentIndex;

    public RoundRobinScheduler()
    {
        items = new List<T>();
        currentIndex = -1;
    }

    public void AddItem(T item)
    {
        items.Add(item);
    }

    public T GetNextItem()
    {
        if (items.Count == 0)
            throw new InvalidOperationException("No items to schedule.");

        currentIndex = (currentIndex + 1) % items.Count;
        return items[currentIndex];
    }
}

