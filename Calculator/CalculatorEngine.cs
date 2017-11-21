namespace Calculator
{
    public class CalculatorEngine
    {
        public int Display
        {
            get { return displayedNumber; }
        }

        public void PressKey(int number)
        {
            displayedNumber = number;
        }

        private int displayedNumber;
    }
}