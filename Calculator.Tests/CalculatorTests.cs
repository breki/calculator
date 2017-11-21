using System;
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

        private int PressANumberKey()
        {
            throw new System.NotImplementedException();
        }

        private void ExpectNumberOnDisplay(int number)
        {
            throw new NotImplementedException();
        }
    }
}