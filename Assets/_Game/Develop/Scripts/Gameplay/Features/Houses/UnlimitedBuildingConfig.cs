using UnityEngine;

namespace Assets.Gameplay.Building
{
    [CreateAssetMenu(fileName = "NewUnlimitedBuildingData", menuName = "Configs/Gameplay/Buildings/UnlimitedBuildingData")]
    public class UnlimitedBuildingConfig : BuildingConfig
    {
        public override bool CanUpgrade(int currentLevel)
        {
            return true;
        }
    }
}
