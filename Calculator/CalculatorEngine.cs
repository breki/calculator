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
            if (keyChars.Count == 1 && keyChars[0] == CharZero)
                keyChars.Clear();

            if (keyPressed == CalculatorKey.Dot)
            {
                if (keyChars.Contains(CharDot))
                    return;

                keyChars.Add(CharDot);
                return;
            }

            if (keyPressed == CalculatorKey.Clr)
            {
                keyChars.Clear();
                Initialize();
                return;
            }

            if (keyPressed == CalculatorKey.Plus)
            {
                StoreCurrentValue();
                clearDisplayOnNextDigit = true;
                return;
            }

            if (keyPressed == CalculatorKey.Equals)
            {
                if (storedValue != 0m)
                {
                    decimal newValue = storedValue * 2;
                    ShowValue(newValue);
                }

                return;
            }

            if (clearDisplayOnNextDigit)
            {
                keyChars.Clear();
                clearDisplayOnNextDigit = false;
            }

            char keyChar = ConvertDigitKeyToCharacter(keyPressed);

            keyChars.Add(keyChar);
        }

        private void ShowValue(decimal newValue)
        {
            keyChars.Clear();
            keyChars.AddRange(newValue.ToString(CultureInfo.InvariantCulture).ToCharArray());
        }

        private void Initialize()
        {
            keyChars.Clear();
            keyChars.Add(CharZero);
        }

        private void StoreCurrentValue()
        {
            storedValue = decimal.Parse(string.Concat(keyChars), CultureInfo.InvariantCulture);
        }

        private static char ConvertDigitKeyToCharacter(CalculatorKey keyPressed)
        {
            return (char)(keyPressed - CalculatorKey.K0 + CharZero);
        }

        private readonly List<char> keyChars = new List<char>();
        private decimal storedValue;
        private bool clearDisplayOnNextDigit;
    }
}