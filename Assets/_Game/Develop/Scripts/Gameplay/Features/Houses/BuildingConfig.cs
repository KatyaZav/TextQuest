using Assets.Untils;
using UnityEngine;

namespace Assets.Gameplay.Building
{
    public abstract class BuildingConfig : ScriptableObject
    {
        public TextTranslate BuildingName { get; private set; }
        public int FirstUpgradeCosts { get; private set; }

        public abstract bool CanUpgrade(int currentLevel); 
    }

    [CreateAssetMenu(fileName = "NewLimitedBuildingData", menuName = "Configs/Gameplay/Buildings/LimitedBuildingData")]
    public class LimitedBuildingConfig : BuildingConfig
    {
        public int maxLevel { get; private set; } = 10;

        public override bool CanUpgrade(int currentLevel)
        {
            return currentLevel + 1 <= maxLevel;
        }
    }

    [CreateAssetMenu(fileName = "NewUnlimitedBuildingData", menuName = "Configs/Gameplay/Buildings/UnlimitedBuildingData")]
    public class UnlimitedBuildingConfig : BuildingConfig
    {
        public override bool CanUpgrade(int currentLevel)
        {
            return true;
        }
    }
}
