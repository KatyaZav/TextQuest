using Assets.Gameplay.Building;
using Assets.Gameplay.Data;
using System;
using UnityEngine;
using UnityEngine.UI;

public class TopView : MonoBehaviour, IDisposable
{
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

    public void Init(GameplaySaves saves, ArmyHolderService armyHolder,
        GameDataInfo gameDataInfo, ReactiveUiFormatFabric formatFabric)
    {
        _saves = saves;
        _armyHolderService = armyHolder;
        _fabric = formatFabric;
        _gameDataInfo = gameDataInfo;

        CreateInfoViews();
        CreateArmyViews();

        _moneyReactive = new ReactiveUI<int>(saves.Money, _money.Text, formatFabric.GetNormalFormat);
        _healthReactive = new ReactiveUI<int>(_gameDataInfo.Health, _health.Text, _fabric.GetColoredFormat);
        _damageReactive = new ReactiveUI<int>(_gameDataInfo.Damage, _damage.Text, _fabric.GetColoredFormat);

        _wizardsReactive = new ReactiveUI<int>(_armyHolderService.WizardHouseService.Count, _wizards.Text, _fabric.GetNormalFormat);
        _archeryReactive = new ReactiveUI<int>(_armyHolderService.ArcheryHouseService.Count, _archery.Text, _fabric.GetNormalFormat);
        _knightsReactive = new ReactiveUI<int>(_armyHolderService.KnightHouseService.Count, _knights.Text, _fabric.GetNormalFormat);
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

    private void CreateInfoViews()
    {
        _health = Instantiate(_iconWithTextPrefab, _gameInfoHolderView);
        _health.name = "Health";

        _damage = Instantiate(_iconWithTextPrefab, _gameInfoHolderView);
        _damage.name = "Damage";

        _money = Instantiate(_iconWithTextPrefab, _gameInfoHolderView);
        _money.name = "Money";
    }
   
    private void CreateArmyViews()
    {
        _archery = Instantiate(_iconWithTextPrefab, _armyHolderView);
        _archery.name = "Archery";

        _wizards = Instantiate(_iconWithTextPrefab, _armyHolderView);
        _wizards.name = "Wizard";

        _knights = Instantiate(_iconWithTextPrefab, _armyHolderView);
        _knights.name = "Knight";
    }
}
