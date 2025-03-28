using UnityEngine;

namespace Assets.Gameplay.Building
{
    [CreateAssetMenu(fileName = "NewLimitedBuildingData", menuName = "Configs/Gameplay/Buildings/LimitedBuildingData")]
    public class LimitedBuildingConfig : BuildingConfig
    {
        [field: SerializeField] public int maxLevel { get; private set; } = 10;

        public override bool CanUpgrade(int currentLevel)
        {
            return currentLevel + 1 <= maxLevel;
        }
    }
}
