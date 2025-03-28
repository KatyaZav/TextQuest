using Assets.Gameplay.Building.Entity;
namespace Assets.Gameplay.Building
{
    public class WizardHouseService : HouseBase
    {
        EntityDataConfig _startEntity;

        private int _count;

        public WizardHouseService(EntityDataConfig startEntity, BuildingConfig buildingConfig, int level)
            : base(buildingConfig, level)
        {
            _startEntity = startEntity;
        }

        public int Count => _count;

        public int GetHealth() =>
            _startEntity.Health * Count;

        public int GetDamage() =>
            _startEntity.Damage * Count;
            
    }
}
