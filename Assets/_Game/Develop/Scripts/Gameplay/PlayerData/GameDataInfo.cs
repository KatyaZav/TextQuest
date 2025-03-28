using DI.Game.Develop.Utils.Reactive;

namespace Assets.Gameplay.Data
{
    public class GameDataInfo
    {
        private GameplaySaves _saves;
        private WeatherSystem _weatherSystem;

        private ReactiveVariable<int> _health = new ReactiveVariable<int>(0);
        private ReactiveVariable<int> _damage = new ReactiveVariable<int>(0);

        public GameDataInfo(GameplaySaves saves, WeatherSystem weather)
        {
            _saves = saves;
            _weatherSystem = weather;
        }

        public IReadOnlyVariable<int> Health => _health;
        public IReadOnlyVariable<int> Damage => _damage;

        public void UpdateHealth()
        {
            int newHealth = 0;
            int newDamage = 0;

            for (var i = 0; i < _saves.Warriors.Count; i++)
            {
                newHealth += _saves.Warriors[i].Health;
                newDamage += _saves.Warriors[i].Damage;
            }

            _health.Value = newHealth;
            _damage.Value = newDamage;

            _health.Value = _weatherSystem.GetFinalHealth(newHealth);
            _damage.Value = _weatherSystem.GetFinalDamage(newDamage);
        }
    }
}