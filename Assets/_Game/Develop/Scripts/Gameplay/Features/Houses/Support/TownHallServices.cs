using Assets.Gameplay.Building;

namespace Assets.Gameplay.Building
{
    public class TownHallServices : HouseBase
    {
        private int _percent = 10;

        public TownHallServices(BuildingConfig buildingConfig, int level,
            int percent, int currentMoney) : base(buildingConfig, level)
        {
            _percent = percent;
            CurrentMoney = currentMoney;
        }

        public int CurrentMoney { get; private set; } = 0;

        public int CollectMoney()
        {
            int coins = CurrentMoney;
            CurrentMoney = 0;
            return coins;
        }

        public void AddMoney()
        {

        }
    }
}
