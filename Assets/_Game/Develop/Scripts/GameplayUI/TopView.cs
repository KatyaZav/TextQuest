using UnityEngine;
using UnityEngine.UI;

public class TopView : MonoBehaviour
{
    [SerializeField] private RectTransform _armyHolderView;
    [SerializeField] private IconWithText _iconWithTextPrefab;

    [Header("Icon with text")]
    [SerializeField] private IconWithText _health;
    [SerializeField] private IconWithText _damage, _money;

    [Header("Weather")]
    [SerializeField] private Image _weatherImage;

    private ReactiveUI<int> _healthReactive, _damageReactive, _moneyReactive;

    public void Init(GameplaySaves saves, ReactiveUiFormatFabric formatFabric)
    {
        _moneyReactive = new ReactiveUI<int>(saves.Money, formatFabric.GetNormalFormat);
    }
}
