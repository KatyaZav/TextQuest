using UnityEngine;

namespace Assets.Gameplay.Building
{
    public class ArmyHolderService : MonoBehaviour
    {
        private WizardHouseService _wizardHouseService;
        private KnightHouseService _knightHouseService;
        private ArcheryHouseService _archeryHouseService;

        public ArmyHolderService(WizardHouseService wizardHouseService,
            KnightHouseService knightHouseService, ArcheryHouseService archeryHouseService)
        {
            _wizardHouseService = wizardHouseService;
            _knightHouseService = knightHouseService;
            _archeryHouseService = archeryHouseService;
        }

        public int GetAllHealth()
        {
            int health = 0;

            health += _wizardHouseService.GetHealth();
            health += _knightHouseService.GetHealth();
            health += _archeryHouseService.GetHealth();

            return health;
        }

        public int GetAllDamage()
        {
            int damage = 0;

            damage += _wizardHouseService.GetDamage();
            damage += _knightHouseService.GetDamage();
            damage += _archeryHouseService.GetDamage();

            return damage;
        }
    }
}
