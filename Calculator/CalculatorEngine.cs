using System.Collections.Generic;

namespace Calculator
{
    public class CalculatorEngine
    {
        public IReadOnlyList<char> Display => digits;

        public void PressKey(char digit)
        {
            digits.Add(digit);
        }

        private readonly List<char> digits = new List<char>();
    }
}