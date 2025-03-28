using Assets.Gameplay.Building;
using Assets.Gameplay.Data;
using DI.Game.Develop.CommonServices.SceneManagment;
using DI.Game.Develop.DI;
using System;
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

            RegistrateArmy(_container);

            _container.Initialize();
        }

        private void ProcessInitialize()
        {
            FindObjectOfType<TopView>().Init(
                _container.Resolve<GameplaySaves>(), _container.Resolve<ReactiveUiFormatFabric>());
        }
        private void ProgressLoadData()
        {

        }

        private void RegistrateArmy(DIContainer container)
        {
            //container.RegisterAsSingle(c => new ArcheryHouseService());
            //container.RegisterAsSingle(c => new KnightHouseService());
            //container.RegisterAsSingle(c => new WizardHouseService());

            container.RegisterAsSingle(c => new ArmyHolderService(
                container.Resolve<WizardHouseService>(),
                container.Resolve<KnightHouseService>(),
                container.Resolve<ArcheryHouseService>()));
        }
    }
}