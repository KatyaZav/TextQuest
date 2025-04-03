using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InputZoneBehavior : MonoBehaviour
{
    [SerializeField] private Button _plusButton, _minusButton;
    [SerializeField] private InputField _inputHolder;

    private int _maxValue = 10;
    private int _currentValue;

    private void OnEnable()
    {
        _inputHolder.onEndEdit.AddListener(OnEndEdit);
    }

    private void OnDisable()
    {
        _inputHolder.onEndEdit.RemoveListener(OnEndEdit);
    }

    public void SetMaxValue(int value)
    {
        _maxValue = value;  
    }

    public void RemoveValue()
    {
        _currentValue--;
        UpdateValues(_currentValue);
    }

    public void AddValue()
    {
        _currentValue++;
        UpdateValues(_currentValue);
    }

    private void OnEndEdit(string text)
    {
        int number = int.Parse(text);

        UpdateValues(number);
    }

    private void UpdateValues(int number)
    {
        if (_maxValue < number)
        {
            number = _maxValue;
            _plusButton.enabled = false;
        }
        else
        {
            _plusButton.enabled = true;
        }

        if (number <= 0)
        {
            number = 0;
            _minusButton.enabled = false;
        }
        else
        {
            _minusButton.enabled = true;
        }

        _inputHolder.text = number.ToString();
        _currentValue = number;
    }
}
