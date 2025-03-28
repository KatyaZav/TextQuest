using Assets.Gameplay.Building;
using Assets.Gameplay.Building.Entity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Gameplay.Building
{
    public class KnightHouseService : HouseBase
    {
        EntityDataConfig _startEntity;
        private int _count;

        public KnightHouseService(EntityDataConfig startEntity, BuildingConfig buildingConfig, int level) : base(buildingConfig, level)
        {
            _startEntity = startEntity;
        }

        public int Count => _count;

        public int GetHealth() =>
            (_startEntity.Health + Level.Value) * Count;

        public int GetDamage() =>
            _startEntity.Damage * Count;
    }
}
