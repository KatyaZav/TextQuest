using Assets.Gameplay.Building.Entity;

namespace Assets.Gameplay.Building
{
    public class ArcheryHouseService : HouseBase
    {
        EntityDataConfig _startEntity;
        private int _count;

        public ArcheryHouseService(EntityDataConfig startEntity, BuildingConfig buildingConfig, int level) : base(buildingConfig, level)
        {
            _startEntity = startEntity;
        }
        
        public int Count => _count;

        public int GetHealth() =>
            _startEntity.Health * Count;

        public int GetDamage() =>
            (_startEntity.Damage + Level.Value) * Count;
    }
}
