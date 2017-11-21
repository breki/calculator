namespace Calculator
{
    public class CalculatorEngine
    {
        public int Display
        {
            get { return displayedNumber; }
        }

        public void PressKey(int digit)
        {
            displayedNumber = digit;
        }

        private int displayedNumber;
    }
}