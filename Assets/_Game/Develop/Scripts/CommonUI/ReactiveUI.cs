using DI.Game.Develop.Utils.Reactive;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ReactiveUI<T> : MonoBehaviour, IDisposable where T : IComparable<T>
{
    private const string GreyColor = "#949494";
    private const string GreenColor = "#00FF1C";
    private const string RedColor = "#FF0000";

    [SerializeField] private Text _text;

    public void Init(IReadOnlyVariable<T> varible)
    {
        _variable = varible;
        _text.text = varible.Value.ToString();

        varible.Changed += OnChanged;
    }

    private IReadOnlyVariable<T> _variable;

    public void Dispose()
    {
        _variable.Changed -= OnChanged;
    }

    private void OnChanged(T oldValue, T newValue)
    {
        string newColor = oldValue.CompareTo(newValue) > 0 ? RedColor : GreenColor;

        _text.text = string.Format("<s><color={0}>{1}</color></s> <color={2}>{3}</color>",
            GreyColor, oldValue, newColor, newValue);
    }
}
