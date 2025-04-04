﻿using DI.Game.Develop.CommonServices.AssetsManagment;
using DI.Game.Develop.Configs.Common.Wallet;
using DI.Game.Develop.Configs.Gameplay;
using System.Diagnostics;
using UnityEngine;

namespace DI.Game.Develop.CommonServices.ConfigsManagment
{
    public class ConfigsProviderService
    {
        private ResourcesAssetLoader _resourcesAssetLoader;

        public ConfigsProviderService(ResourcesAssetLoader resourcesAssetLoader)
        {
            _resourcesAssetLoader = resourcesAssetLoader;
        }

        public StartWalletConfig StartWalletConfig { get; private set; }

        public CurrencyIconsConfig CurrencyIconsConfig { get; private set; }

        public LevelListConfig LevelsListConfig { get; private set; }   

        public void LoadAll()
        {
            //подгружать конфиги из ресурсов
            UnityEngine.Debug.LogError("Cheak all configs");

            LoadStartWalletConfig();
            LoadCurrencyIconsConfig();
            LoadLevelsListConfig();
        }

        private void LoadStartWalletConfig()
            => StartWalletConfig = _resourcesAssetLoader.LoadResource<StartWalletConfig>("Configs/Common/Wallet/StartWalletConfig");

        private void LoadCurrencyIconsConfig()
            => CurrencyIconsConfig = _resourcesAssetLoader.LoadResource<CurrencyIconsConfig>("Configs/Common/Wallet/CurrencyIconsConfig");

        private void LoadLevelsListConfig()
            => LevelsListConfig = _resourcesAssetLoader.LoadResource<LevelListConfig>("Configs/Gameplay/Levels/LevelListConfig");
    }
}
