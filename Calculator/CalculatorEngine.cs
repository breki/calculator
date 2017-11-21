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

        public void PressKey(CalculatorKey keyPressed)
        {
            if (keyChars.Count == 1 && keyChars[0] == KeyZero)
                keyChars.Clear();

            if (keyPressed == CalculatorKey.Dot)
            {
                if (keyChars.Contains(KeyDot))
                    return;
                
                keyChars.Add(KeyDot);
                return;
            }

            if (keyPressed == CalculatorKey.Clr)
            {
                keyChars.Clear();
                keyChars.Add(KeyZero);
                return;
            }

            char keyChar = (char)(keyPressed - CalculatorKey.K0 + '0');

            keyChars.Add(keyChar);
        }

        private readonly List<char> keyChars = new List<char>();
    }
}