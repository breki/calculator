using System.Collections.Generic;

namespace Calculator
{
    public class CalculatorEngine
    {
        public CalculatorEngine()
        {
            keyChars.Add(KeyZero);
        }

        public const char KeyDot = '.';
        public const char KeyZero = '0';

        public IReadOnlyList<char> Display => keyChars;

        public void PressKey(char keyChar)
        {
            if (keyChars.Count == 1 && keyChars[0] == KeyZero)
                keyChars.Clear();

            if (keyChar == KeyDot && keyChars.Contains(KeyDot))
                return;

            keyChars.Add(keyChar);
        }

        private readonly List<char> keyChars = new List<char>();
    }
}