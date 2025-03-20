using DI.Game.Develop.Utils.Reactive;
using System;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class ReactiveUI<T> : IDisposable where T : IComparable<T>
{
    [SerializeField] private Text _text;
    
    private Func<T, T, string> _formatText;

    public ReactiveUI(IReadOnlyVariable<T> varible, Func<T, T, string> formatText)
    {
        _variable = varible;
        _formatText = formatText;
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
        _text.text = _formatText(oldValue, newValue);
    }
}
