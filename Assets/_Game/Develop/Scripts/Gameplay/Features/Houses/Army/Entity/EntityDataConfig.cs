using Assets.Untils;
using UnityEngine;

namespace Assets.Gameplay.Building.Entity
{
    [CreateAssetMenu(fileName = "NewEntityData", menuName = "Configs/Gameplay/Entity/EntityData")]
    public class EntityDataConfig : ScriptableObject
    {
        [field: SerializeField] public TextTranslate Name { get; private set; }
        [field: SerializeField] public int Health { get; private set; } = 0;
        [field: SerializeField] public int Damage { get; private set; } = 0;
    }
}