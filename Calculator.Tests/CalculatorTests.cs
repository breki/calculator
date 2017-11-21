using NUnit.Framework;

namespace Calculator.Tests
{
    public class CalculatorTests
    {
        [Test]
        public void PressingNumberKeyDisplaysThatNumber()
        {
            int number = PressANumberKey();
            ExpectNumberOnDisplay(number);
        }
    }
}