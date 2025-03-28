using DI.Game.Develop.Utils.Reactive;

namespace Assets.Gameplay.Building
{
    public class HouseBase
    {
        private BuildingConfig _buildingConfig;
        private ReactiveVariable<int> _level;

        public HouseBase(BuildingConfig buildingConfig, int level)
        {
            _buildingConfig = buildingConfig;
            _level = new ReactiveVariable<int>(level);
        }

        public IReadOnlyVariable<int> Level => _level;
        public bool CanUpgrade => _buildingConfig.CanUpgrade(Level.Value);

        public void Upgrade()
        {
            if (CanUpgrade == false)
                throw new System.Exception($"Can't upgrade building {_buildingConfig.BuildingName.English}");

            _level.Value += 1;
        }
    }
}
