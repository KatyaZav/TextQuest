using Assets.Gameplay.Building;
using Assets.Gameplay.Building.Entity;
using DI.Game.Develop.Utils.Reactive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Gameplay.Building
{
    public class KnightHouseService : HouseBase
    {
        public EntityHolder EntityHolder;
        
        private EntityDataConfig _startEntity;

        public KnightHouseService(EntityDataConfig startEntity, BuildingConfig buildingConfig, int level) : base(buildingConfig, level)
        {
            _startEntity = startEntity;
            EntityHolder = new EntityHolder(0, Level);
        }

        public IReadOnlyVariable<int> Count => EntityHolder.Count;

        public int GetHealth() =>
            (_startEntity.Health + Level.Value) * Count.Value;

        public int GetDamage() =>
            _startEntity.Damage * Count.Value;
    }
}
