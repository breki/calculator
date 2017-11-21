using System.Collections.Generic;

namespace Calculator
{
    public class CalculatorEngine
    {
        public IReadOnlyList<char> Display => keyChars;

        public void PressKey(char keyChar)
        {
            keyChars.Add(keyChar);
        }

        private readonly List<char> keyChars = new List<char>();
    }
}