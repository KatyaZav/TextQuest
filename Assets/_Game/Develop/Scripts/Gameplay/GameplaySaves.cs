using DI.Game.Develop.Utils.Reactive;
using System.Collections.Generic;

public class GameplaySaves
{
    private List<Warrior> _warriors = new List<Warrior>();

    private ReactiveVariable<int> _wizardCount = new ReactiveVariable<int>(0);
    private ReactiveVariable<int> _archeryCount = new ReactiveVariable<int>(0);
    private ReactiveVariable<int> _knightsCount = new ReactiveVariable<int>(0);

    private ReactiveVariable<int> _money = new ReactiveVariable<int>(0);
    private ReactiveVariable<int> _wave = new ReactiveVariable<int>(0);

    public IReadOnlyVariable<int> WizardsCount => _wizardCount;
    public IReadOnlyVariable<int> ArcheriesCount => _archeryCount;
    public IReadOnlyVariable<int> KnightsCount => _knightsCount;

    public IReadOnlyVariable<int> Money => _money;
    public IReadOnlyVariable<int> Wave => _wave;

    public IReadOnlyList<Warrior> Warriors => _warriors;

    public void LoadData(GameplaySaves saves)
    {
        _warriors = new List<Warrior>(Warriors);

        _wizardCount = new ReactiveVariable<int>(saves.WizardsCount.Value);
        _archeryCount = new ReactiveVariable<int>(saves.ArcheriesCount.Value);
        _knightsCount = new ReactiveVariable<int>(saves.KnightsCount.Value);

        _money = new ReactiveVariable<int>(saves.Money.Value);
        _wave = new ReactiveVariable<int>(saves.Wave.Value);
    }

    public void AddNewWarrior(Warrior warrior)
    {
        _warriors.Add(warrior);
        warrior.Activate();
    }
}
