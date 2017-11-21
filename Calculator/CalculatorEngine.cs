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
            if (keyPressed == CalculatorKey.Plus)
            {
                currentOperator = keyPressed;
                StoreCurrentValue();
                clearDisplayOnNextDigit = true;
                return;
            }

            if (keyPressed == CalculatorKey.Equals)
            {
                if (currentOperator == null)
                    return;

                StoreCurrentValue();

                if (valuesStack.Count > 0)
                {
                    decimal newValue = valuesStack.Pop() + valuesStack.Pop();
                    ShowValue(newValue);
                }

                return;
            }

            if (keyPressed == CalculatorKey.Dot)
            {
                if (keyChars.Contains(CharDot))
                    return;

                keyChars.Add(CharDot);
                return;
            }

            if (keyPressed == CalculatorKey.Clr)
            {
                Initialize();
                return;
            }

            ClearDisplayIfNeeded();

            char keyChar = ConvertDigitKeyToCharacter(keyPressed);

            keyChars.Add(keyChar);
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