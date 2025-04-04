﻿using DI.Game.Develop.CommonServices.ConfigsManagment;
using DI.Game.Develop.CommonServices.DataManagment.DataProviders;
using DI.Game.Develop.CommonServices.LoadingScreen;
using DI.Game.Develop.CommonServices.SceneManagment;
using DI.Game.Develop.DI;
using System.Collections;
using UnityEngine;

namespace DI.Game.Develop.EntryPoint
{
    //Если entry point - это просто глобальные регистрации для старта проекта,
    //то bootstrap - уже инициализация начала работ
    public class Bootstrap : MonoBehaviour
    {
        public IEnumerator Run(DIContainer container)
        {
            ILoadingCurtain loadingCurtain = container.Resolve<ILoadingCurtain>();
            SceneSwitcher sceneSwitcher = container.Resolve<SceneSwitcher>();

            loadingCurtain.Show();

            Debug.Log("Начинается инициализация сервисов");

            //Инициализаций всех (подгрузка данных/конфигов/инит сервисов рекламы/аналитики и тп)

            container.Resolve<ConfigsProviderService>().LoadAll();
            container.Resolve<PlayerDataProvider>().Load();

            yield return new WaitUntil(() => YG.YandexGame.SDKEnabled);//инициализация какого-то процесса инициализация

            Debug.Log("Завершается инициализация сервисов проекта, начинается переход на какую-то сцену");

            loadingCurtain.Hide();

            //переход на следующий сцену с помощью сервиса смены сцен

            sceneSwitcher.ProcessSwitchSceneFor(new OutpurBootstrapArgs(new GameplayInputArgs()));
        }
    }
}
