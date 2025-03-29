using DI.Game.Develop.Utils.Reactive;
using System;

public class EntityHolder
{
    private ReactiveVariable<int> _count;
    private IReadOnlyVariable<int> _level;

    public EntityHolder(int count, IReadOnlyVariable<int> level)
    {
        _count = new ReactiveVariable<int>(count);
        _level = level;
    }

    public IReadOnlyVariable<int> Count => _count;

    public bool CanAdd(int count) => _count.Value + count <= (_level.Value + 1) * 10;

    public void Add(int count)
    {
        if (CanAdd(count) == false)
            throw new Exception("Can't add more units!");

        _count.Value += count;
    }

    public void Remove(int count)
    {
        if (Count.Value < count)
            throw new System.Exception($"Cant remove {count} count from {Count} people. Not enought");

        _count.Value -= count;
    }
}
