using System.Collections.Generic;

namespace Calculator
{
    public class CalculatorEngine
    {
        public const char KeyDot = '.';

        public IReadOnlyList<char> Display => keyChars;

        public void PressKey(char keyChar)
        {
            if (keyChar == KeyDot && keyChars.Contains(KeyDot))
                return;

            keyChars.Add(keyChar);
        }

        private readonly List<char> keyChars = new List<char>();
    }
}