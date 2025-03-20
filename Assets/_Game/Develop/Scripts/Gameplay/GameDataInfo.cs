using DI.Game.Develop.Utils.Reactive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataInfo
{
    private GameplaySaves _saves;
    
    private ReactiveVariable<int> _health = new ReactiveVariable<int>(0);
    private ReactiveVariable<int> _damage = new ReactiveVariable<int>(0);

    public GameDataInfo(GameplaySaves saves)
    {
        _saves = saves;
    }

    public IReadOnlyVariable<int> Health => _health;
    public IReadOnlyVariable<int> Damage => _damage;

    public void UpdateHealth()
    {
        int newHealth = 0;
        int newDamage = 0;

        for (var i = 0; i < _saves.Warriors.Count; i++)
        {
            newHealth += _saves.Warriors[i].Health;
            newDamage += _saves.Warriors[i].Damage;
        }


    }
}
