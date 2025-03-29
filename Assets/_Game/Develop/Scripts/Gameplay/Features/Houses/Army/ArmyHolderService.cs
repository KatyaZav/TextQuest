using UnityEngine;

namespace Assets.Gameplay.Building
{
    public class ArmyHolderService
    {
        public WizardHouseService WizardHouseService;
        public KnightHouseService KnightHouseService;
        public ArcheryHouseService ArcheryHouseService;

        public ArmyHolderService(WizardHouseService wizardHouseService,
            KnightHouseService knightHouseService, ArcheryHouseService archeryHouseService)
        {
            WizardHouseService = wizardHouseService;
            KnightHouseService = knightHouseService;
            ArcheryHouseService = archeryHouseService;
        }

        public int GetAllHealth()
        {
            int health = 0;

            health += WizardHouseService.GetHealth();
            health += KnightHouseService.GetHealth();
            health += ArcheryHouseService.GetHealth();

            return health;
        }

        public int GetAllDamage()
        {
            int damage = 0;

            damage += WizardHouseService.GetDamage();
            damage += KnightHouseService.GetDamage();
            damage += ArcheryHouseService.GetDamage();

            return damage;
        }
    }
}
