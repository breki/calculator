using System.Collections.Generic;

namespace Calculator
{
    public class CalculatorEngine
    {
        public IList<char> Display
        {
            get { return digits; }
        }

        public void PressKey(char digit)
        {
            digits.Add(digit);
        }

        private List<char> digits = new List<char>();
    }
}