using Assets.Untils;
using UnityEngine;

namespace Assets.Gameplay.Building
{
    public abstract class BuildingConfig : ScriptableObject
    {
        [field:SerializeField] public TextTranslate BuildingName { get; private set; }
        [field: SerializeField] public int FirstUpgradeCosts { get; private set; }

        public abstract bool CanUpgrade(int currentLevel); 
    }
}
