using Assets.Gameplay.Building;
using Assets.Gameplay.Data;
using DI.Game.Develop.CommonServices.AssetsManagment;
using System;
using UnityEngine;
using UnityEngine.UI;

public class TopView : MonoBehaviour, IDisposable
{
    private const string IconsPath = "Images/Icons/";

    [Header("Holders rect transform")]
    [SerializeField] private RectTransform _armyHolderView;
    [SerializeField] private RectTransform _gameInfoHolderView;

    [Header("Prefabs")]
    [SerializeField] private IconWithText _iconWithTextPrefab;

    [Header("Weather")]
    [SerializeField] private Image _weatherImage;

    private IconWithText _health, _damage, _money;
    private IconWithText _wizards, _knights, _archery;

    private ReactiveUI<int> _healthReactive, _damageReactive, _moneyReactive;
    private ReactiveUI<int> _wizardsReactive, _knightsReactive, _archeryReactive;

    private GameplaySaves _saves;
    private ArmyHolderService _armyHolderService;
    private ReactiveUiFormatFabric _fabric;
    private GameDataInfo _gameDataInfo;
    private ResourcesAssetLoader _loader;

    public void Init(GameplaySaves saves, ArmyHolderService armyHolder,
        GameDataInfo gameDataInfo, ResourcesAssetLoader loader , ReactiveUiFormatFabric formatFabric)
    {
        _saves = saves;
        _armyHolderService = armyHolder;
        _fabric = formatFabric;
        _gameDataInfo = gameDataInfo;
        _loader = loader;

        CreateInfoViews();
        CreateArmyViews();
    }

    public void Dispose()
    {
        _moneyReactive.Dispose();
        _healthReactive.Dispose();
        _damageReactive.Dispose();

        _archeryReactive.Dispose();
        _wizardsReactive.Dispose();
        _knightsReactive.Dispose();
    }

    private void OnDisable()
    {
        Dispose();
    }

    private Sprite GetSprite(string path)
    {
        return _loader.LoadResource<Sprite>(IconsPath + path);
    }

    private void CreateInfoViews()
    {
        _health = Instantiate(_iconWithTextPrefab, _gameInfoHolderView);
        _health.name = "Health";
        _health.Icon.sprite = GetSprite(_health.name);
        _healthReactive = new ReactiveUI<int>(_gameDataInfo.Health, _health.Text, _fabric.GetColoredFormat);

        _damage = Instantiate(_iconWithTextPrefab, _gameInfoHolderView);
        _damage.name = "Damage";
        _damage.Icon.sprite = GetSprite(_damage.name);  
        _damageReactive = new ReactiveUI<int>(_gameDataInfo.Damage, _damage.Text, _fabric.GetColoredFormat);

        _money = Instantiate(_iconWithTextPrefab, _gameInfoHolderView);
        _money.name = "Money";
        _money.Icon.sprite = GetSprite(_money.name);
        _moneyReactive = new ReactiveUI<int>(_saves.Money, _money.Text, _fabric.GetNormalFormat);

        LayoutRebuilder.ForceRebuildLayoutImmediate(_gameInfoHolderView.GetComponent<RectTransform>());
    }

    private void CreateArmyViews()
    {
        _archery = Instantiate(_iconWithTextPrefab, _armyHolderView);
        _archery.name = "Archery";
        _archery.Icon.sprite = GetSprite(_archery.name);
        _archeryReactive = new ReactiveUI<int>(_armyHolderService.ArcheryHouseService.Count, _archery.Text, _fabric.GetNormalFormat);

        _wizards = Instantiate(_iconWithTextPrefab, _armyHolderView);
        _wizards.name = "Wizard";
        _wizards.Icon.sprite = GetSprite(_wizards.name);
        _wizardsReactive = new ReactiveUI<int>(_armyHolderService.WizardHouseService.Count, _wizards.Text, _fabric.GetNormalFormat);

        _knights = Instantiate(_iconWithTextPrefab, _armyHolderView);
        _knights.name = "Knight";
        _knights.Icon.sprite = GetSprite(_knights.name);
        _knightsReactive = new ReactiveUI<int>(_armyHolderService.KnightHouseService.Count, _knights.Text, _fabric.GetNormalFormat);
    }
}
