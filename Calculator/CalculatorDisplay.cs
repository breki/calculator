using System.Collections.Generic;

namespace Calculator
{
    public class CalculatorDisplay
    {
        public string Text => string.Concat(keyChars);

        public bool ShowsZero => keyChars.Count == 1 && keyChars[0] == CalculatorEngine.CharZero;

        public bool ContainsDot => keyChars.Contains(CalculatorEngine.CharDot);

        public void AddCharacter(char keyChar)
        {
            keyChars.Add(keyChar);
        }

        public void AddCharacters(IEnumerable<char> characters)
        {
            keyChars.AddRange(characters);
        }

        public void Clear()
        {
            keyChars.Clear();
        }

        private readonly List<char> keyChars = new List<char>();
    }
}