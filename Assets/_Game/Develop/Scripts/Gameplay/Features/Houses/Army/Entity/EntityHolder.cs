public class EntityHolder
{
    private int _count;

    public EntityHolder(int count)
    {
        _count = count;
    }

    public int Count => _count;

    public void Add(int count)
    {
        _count += count;
    }

    public void Remove(int count)
    {
        if (Count < count)
            throw new System.Exception($"Cant remove {count} count from {Count} people. Not enought");

        _count -= count;
    }
}
