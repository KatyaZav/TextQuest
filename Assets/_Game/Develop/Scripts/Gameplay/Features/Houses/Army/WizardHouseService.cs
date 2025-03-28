using Assets.Gameplay.Building.Entity;
namespace Assets.Gameplay.Building
{
    public class WizardHouseService : HouseBase
    {
        public EntityHolder EntityHolder;

        private EntityDataConfig _startEntity;

        public WizardHouseService(EntityDataConfig startEntity, BuildingConfig buildingConfig, int level)
            : base(buildingConfig, level)
        {
            _startEntity = startEntity;
            EntityHolder = new EntityHolder(0);
        }

        public int Count => EntityHolder.Count;

        public int GetHealth() =>
            _startEntity.Health * Count;

        public int GetDamage() =>
            _startEntity.Damage * Count;
    }
}
