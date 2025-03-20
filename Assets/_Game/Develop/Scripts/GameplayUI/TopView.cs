using UnityEngine;
using UnityEngine.UI;

public class TopView : MonoBehaviour
{
    [Header("Holders rect transform")]
    [SerializeField] private RectTransform _armyHolderView;
    [SerializeField] private RectTransform _gameInfoHolderView;

    [Header("Prefabs")]
    [SerializeField] private IconWithText _iconWithTextPrefab;

    [Header("Weather")]
    [SerializeField] private Image _weatherImage;

    private IconWithText _health, _damage, _money;

    private ReactiveUI<int> _healthReactive, _damageReactive, _moneyReactive;

    public void Init(GameplaySaves saves, ReactiveUiFormatFabric formatFabric)
    {
        CreateInfoViews();

        _moneyReactive = new ReactiveUI<int>(saves.Money, _money.Text, formatFabric.GetNormalFormat);
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
}
