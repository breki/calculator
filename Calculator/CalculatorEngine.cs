using System;
using System.Collections.Generic;
using System.Globalization;

namespace Calculator
{
    public class CalculatorEngine
    {
        public CalculatorEngine()
        {
            Initialize();
        }

        public const char CharDot = '.';
        public const char CharZero = '0';

        public IReadOnlyList<char> Display => keyChars;

        public void PressKey(CalculatorKey keyPressed)
        {
            switch (keyPressed)
            {
                case CalculatorKey.Plus:
                case CalculatorKey.Minus:
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
            keyChars.Add(keyChar);
        }

        private void HandleOperatorKey(CalculatorKey keyPressed)
        {
            currentOperator = keyPressed;
            StoreCurrentValue();
            clearDisplayOnNextDigit = true;
        }

        private void HandleEqualsKey()
        {
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
                default:
                    throw new InvalidOperationException();
            }

            ShowValue(newValue);
        }

        private void HandleDotKey()
        {
            if (keyChars.Contains(CharDot))
                return;

            keyChars.Add(CharDot);
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
            else if (keyChars.Count == 1 && keyChars[0] == CharZero)
                displayShouldBeCleared = true;

            if (!displayShouldBeCleared)
                return;

            ClearDisplay();
            clearDisplayOnNextDigit = false;
        }

        private void ShowValue(decimal newValue)
        {
            ClearDisplay();
            if (newValue == 0)
                keyChars.Add(CharZero);
            else
                keyChars.AddRange(newValue.ToString(CultureInfo.InvariantCulture).ToCharArray());
        }

        private void Initialize()
        {
            ClearDisplay();
            keyChars.Add(CharZero);
        }

        private void ClearDisplay()
        {
            keyChars.Clear();
        }

        private void StoreCurrentValue()
        {
            valuesStack.Push(decimal.Parse(string.Concat(keyChars), CultureInfo.InvariantCulture));
        }

        private static char ConvertDigitKeyToCharacter(CalculatorKey keyPressed)
        {
            return (char)(keyPressed - CalculatorKey.K0 + CharZero);
        }

        private readonly List<char> keyChars = new List<char>();
        private readonly Stack<decimal> valuesStack = new Stack<decimal>();
        private bool clearDisplayOnNextDigit;
        private CalculatorKey? currentOperator;
    }
}