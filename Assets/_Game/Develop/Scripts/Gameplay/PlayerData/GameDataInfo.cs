using Assets.Gameplay.Building;
using DI.Game.Develop.Utils.Reactive;

namespace Assets.Gameplay.Data
{
    public class GameDataInfo
    {
        private ArmyHolderService _armyHolder;
        private WeatherSystem _weatherSystem;

        private ReactiveVariable<int> _health = new ReactiveVariable<int>(0);
        private ReactiveVariable<int> _damage = new ReactiveVariable<int>(0);

        public GameDataInfo(ArmyHolderService saves, WeatherSystem weather)
        {
            _armyHolder = saves;
            _weatherSystem = weather;
        }

        public IReadOnlyVariable<int> Health => _health;
        public IReadOnlyVariable<int> Damage => _damage;

        public void UpdateHealth()
        {
            int newHealth = _armyHolder.GetAllHealth();
            int newDamage = _armyHolder.GetAllDamage();

            _health.Value = newHealth;
            _damage.Value = newDamage;

            _health.Value = _weatherSystem.GetFinalHealth(newHealth);
            _damage.Value = _weatherSystem.GetFinalDamage(newDamage);
        }
    }
}