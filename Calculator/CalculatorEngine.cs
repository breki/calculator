using System.Collections.Generic;

namespace Calculator
{
    public class CalculatorEngine
    {
        public CalculatorEngine()
        {
            keyChars.Add('0');
        }

        public const char KeyDot = '.';

        public IReadOnlyList<char> Display => keyChars;

        public void PressKey(char keyChar)
        {
            if (keyChars.Count == 1 && keyChars[0] == '0')
                keyChars.Clear();

            if (keyChar == KeyDot && keyChars.Contains(KeyDot))
                return;

            keyChars.Add(keyChar);
        }

        private readonly List<char> keyChars = new List<char>();
    }
}