using System;
using System.Collections.Generic;
using System.Globalization;

namespace Calculator
{
    public class CalculatorEngine
    {
        public CalculatorEngine(CalculatorDisplay display)
        {
            this.display = display;
            Initialize();
        }

        public const char CharDot = '.';
        public const char CharZero = '0';

        public void PressKey(CalculatorKey keyPressed)
        {
            switch (keyPressed)
            {
                case CalculatorKey.Plus:
                case CalculatorKey.Minus:
                case CalculatorKey.Multiply:
                case CalculatorKey.Divide:
                    HandleOperatorKey(keyPressed);
                    return;

                case CalculatorKey.Equals:
                    HandleEqualsKey();
                    return;

                case CalculatorKey.Dot:
                    HandleDotKey();
                    return;

                case CalculatorKey.Clr:
                    HandleClrKey();
                    return;
            }

            ClearDisplayIfNeeded();

            char keyChar = ConvertDigitKeyToCharacter(keyPressed);
            display.AddCharacter(keyChar);
        }

        private void Initialize()
        {
            ClearDisplay();
            display.AddCharacter(CharZero);
        }

        private void HandleOperatorKey(CalculatorKey keyPressed)
        {
            currentOperator = keyPressed;
            StoreCurrentValue();
            clearDisplayOnNextDigit = true;
        }

        private void HandleEqualsKey()
        {
            clearDisplayOnNextDigit = true;

            if (currentOperator == null)
                return;

            StoreCurrentValue();

            if (valuesStack.Count <= 0)
                return;

            decimal newValue;
            switch (currentOperator)
            {
                case CalculatorKey.Plus:
                    newValue = valuesStack.Pop() + valuesStack.Pop();
                    break;
                case CalculatorKey.Minus:
                    newValue = -(valuesStack.Pop() - valuesStack.Pop());
                    break;
                case CalculatorKey.Multiply:
                    newValue = valuesStack.Pop() * valuesStack.Pop();
                    break;
                case CalculatorKey.Divide:
                    decimal divisor = valuesStack.Pop();
                    decimal dividend = valuesStack.Pop();

                    if (divisor == 0m)
                    {
                        display.DisplayErrorMessage();
                        return;
                    }

                    newValue = dividend / divisor;
                    break;
                default:
                    throw new InvalidOperationException();
            }

            ShowValue(newValue);
        }

        private void HandleDotKey()
        {
            if (!display.ContainsDot)
                display.AddCharacter(CharDot);
        }

        private void HandleClrKey()
        {
            Initialize();
        }

        private void ClearDisplayIfNeeded()
        {
            bool displayShouldBeCleared = false;
            if (clearDisplayOnNextDigit)
                displayShouldBeCleared = true;
            else if (display.ShowsZero)
                displayShouldBeCleared = true;

            if (!displayShouldBeCleared)
                return;

            ClearDisplay();
            clearDisplayOnNextDigit = false;
        }

        private void ShowValue(decimal newValue)
        {
            display.DisplayValue(newValue);
        }

        private void ClearDisplay()
        {
            display.Clear();
        }

        private void StoreCurrentValue()
        {
            valuesStack.Push(decimal.Parse(display.Text, CultureInfo.InvariantCulture));
        }

        private static char ConvertDigitKeyToCharacter(CalculatorKey keyPressed)
        {
            return (char)(keyPressed - CalculatorKey.K0 + CharZero);
        }

        private readonly Stack<decimal> valuesStack = new Stack<decimal>();
        private bool clearDisplayOnNextDigit;
        private CalculatorKey? currentOperator;
        private readonly CalculatorDisplay display;
    }
}