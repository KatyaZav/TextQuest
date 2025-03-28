using DI.Game.Develop.Utils.Reactive;

public class GameplaySaves
{
    private ReactiveVariable<int> _money = new ReactiveVariable<int>(0);
    private ReactiveVariable<int> _wave = new ReactiveVariable<int>(0);

    public IReadOnlyVariable<int> Money => _money;
    public IReadOnlyVariable<int> Wave => _wave;

    public void LoadData(GameplaySaves saves)
    {
        _money = new ReactiveVariable<int>(saves.Money.Value);
        _wave = new ReactiveVariable<int>(saves.Wave.Value);
    }
}
