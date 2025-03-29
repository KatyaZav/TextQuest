using Assets.Gameplay.Building.Entity;
using DI.Game.Develop.Utils.Reactive;
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
            EntityHolder = new EntityHolder(0, Level);
        }

        public IReadOnlyVariable<int> Count => EntityHolder.Count;

        public int GetHealth() =>
            _startEntity.Health * Count.Value;

        public int GetDamage() =>
            _startEntity.Damage * Count.Value;

        public int GetMana() =>
            Count.Value * 10;
    }
}
