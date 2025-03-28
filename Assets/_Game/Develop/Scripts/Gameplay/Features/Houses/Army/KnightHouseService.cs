using Assets.Gameplay.Building;
using Assets.Gameplay.Building.Entity;
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
            EntityHolder = new EntityHolder(0);
        }

        public int Count => EntityHolder.Count;

        public int GetHealth() =>
            (_startEntity.Health + Level.Value) * Count;

        public int GetDamage() =>
            _startEntity.Damage * Count;
    }
}
