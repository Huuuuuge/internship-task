using System;
using TMPro;
using UnityEngine;

public class Calculator : MonoBehaviour
{
    #region Fields
    public TextMeshProUGUI InputText;
    private float _result;
    private string _currentInput;
    private bool _equalIsPressed;
    #endregion Fields
    
    #region Methods
    public void ClickNumber(int val)
    {
        if (_equalIsPressed)
        {
            ClearInput();
            _equalIsPressed = false;
        }
        
        _currentInput += val;
        InputText.text += val.ToString();
    }
    
    public void ClickOperation(string val)
    {
        if (!string.IsNullOrEmpty(_currentInput))
        {
            _currentInput += " " + val + " ";
            InputText.text += " " + val + " ";
        }
    }
    
    public void ClickEqual(string val)
    {
        if (!string.IsNullOrEmpty(_currentInput))
        {
            Calculate();
            _equalIsPressed = true;
        }
    }

    private void Calculate()
    {
        string[] expression = _currentInput.Split(' ');
        
        if (expression.Length == 3)
        {
            float operand1 = float.Parse(expression[0]);
            string operation = expression[1];
            float operand2 = float.Parse(expression[2]);
            
            switch (operation)
            {
                case "+":
                    _result = operand1 + operand2;
                    break;
                case "-":
                    _result = operand1 - operand2;
                    break;
                case "*":
                    _result = operand1 * operand2;
                    break;
                case "/":
                    _result = operand1 / operand2;
                    break;
            }
            
            InputText.text = _result.ToString();
            _currentInput = _result.ToString();
        }
    }

    // Clear all the inputs
    public void ClearInput()
    {
        _currentInput = "";
        _result = 0;
        InputText.SetText("");
    }
    #endregion Methods
}





