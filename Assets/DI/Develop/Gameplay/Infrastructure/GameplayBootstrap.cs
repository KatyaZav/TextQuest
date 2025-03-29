using Assets.Gameplay.Building;
using Assets.Gameplay.Building.Entity;
using Assets.Gameplay.Data;
using DI.Game.Develop.CommonServices.AssetsManagment;
using DI.Game.Develop.CommonServices.SceneManagment;
using DI.Game.Develop.DI;
using System.Collections;
using UnityEngine;

namespace DI.Game.Develop.Gameplay.Infrastructure
{
    public class GameplayBootstrap : MonoBehaviour
    {
        private DIContainer _container;

        public IEnumerator Run(DIContainer container, GameplayInputArgs gameplayInputArgs)
        {
            _container = container;

            ProcessRegistrations();
            ProgressLoadData();
            ProcessInitialize();
                        
            yield return null;
        }

        private void ProcessRegistrations()
        {
            _container.RegisterAsSingle(c => new ReactiveUiFormatFabric());
            _container.RegisterAsSingle(c => new GameplaySaves());
            _container.RegisterAsSingle(c => new WeatherSystem());

            _container.RegisterAsSingle(c => new GameDataInfo(
                _container.Resolve<ArmyHolderService>(), _container.Resolve<WeatherSystem>()));

            RegistrateArmy(_container);

            _container.Initialize();
        }

        private void ProcessInitialize()
        {
            FindObjectOfType<TopView>().Init(
                _container.Resolve<GameplaySaves>(),
                _container.Resolve<ArmyHolderService>(),
                _container.Resolve<GameDataInfo>(),
                _container.Resolve<ReactiveUiFormatFabric>());
        }
        private void ProgressLoadData()
        {

        }

        private void RegistrateArmy(DIContainer container)
        {
            ResourcesAssetLoader loader = container.Resolve<ResourcesAssetLoader>();

            EntityDataConfig archeryData = loader.LoadResource<EntityDataConfig>("Configs/Gameplay/ArmyEntity/Archery");
            EntityDataConfig knightData = loader.LoadResource<EntityDataConfig>("Configs/Gameplay/ArmyEntity/Knight");
            EntityDataConfig wizardData = loader.LoadResource<EntityDataConfig>("Configs/Gameplay/ArmyEntity/Witch");

            BuildingConfig archeryBuildingConfig = loader.LoadResource<BuildingConfig>("Configs/Gameplay/Building/Archery");
            BuildingConfig knightBuildingConfig = loader.LoadResource<BuildingConfig>("Configs/Gameplay/Building/Barracks");
            BuildingConfig wizardBuildingConfig = loader.LoadResource<BuildingConfig>("Configs/Gameplay/Building/MagicUnion");

            container.RegisterAsSingle(c => new ArcheryHouseService(archeryData, archeryBuildingConfig, 0));
            container.RegisterAsSingle(c => new KnightHouseService(knightData, knightBuildingConfig, 0));
            container.RegisterAsSingle(c => new WizardHouseService(wizardData, wizardBuildingConfig, 0));

            container.RegisterAsSingle(c => new ArmyHolderService(
                container.Resolve<WizardHouseService>(),
                container.Resolve<KnightHouseService>(),
                container.Resolve<ArcheryHouseService>()));
        }
    }
}