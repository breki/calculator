using System;
using System.Collections.Generic;
using System.Globalization;

namespace Calculator
{
    public class CalculatorDisplay
    {
        public const string MsgError = "ERR";

        public string Text => string.Concat(keyChars);

        public bool ShowsZero => keyChars.Count == 1 && keyChars[0] == CalculatorEngine.CharZero;

        public bool ContainsDot => keyChars.Contains(CalculatorEngine.CharDot);

        public void AddCharacter(char keyChar)
        {
            keyChars.Add(keyChar);
        }

        public void DisplayErrorMessage()
        {
            DisplayText(MsgError);
        }

        public void DisplayValue(decimal value)
        {
            Clear();
            if (value == 0)
                AddCharacter(CalculatorEngine.CharZero);
            else
            {
                decimal roundedValue = Math.Round(value, 8);
                AddCharacters(roundedValue.ToString(CultureInfo.InvariantCulture).ToCharArray());
            }
        }

        public void Clear()
        {
            keyChars.Clear();
        }

        private void DisplayText(string text)
        {
            Clear();
            AddCharacters(text);
        }

        private void AddCharacters(IEnumerable<char> characters)
        {
            keyChars.AddRange(characters);
        }

        private readonly List<char> keyChars = new List<char>();
    }
}