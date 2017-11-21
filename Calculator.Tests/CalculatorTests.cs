using System;
using NUnit.Framework;

namespace Calculator.Tests
{
    public class CalculatorTests
    {
        [Test]
        public void PressingDigitKeyDisplaysThatDigit()
        {
            int digit = PressADigitKey();
            ExpectDigitOnDisplay(digit);
        }

        [SetUp]
        public void Setup()
        {
            calculator = new CalculatorEngine();
        }

        private int PressADigitKey()
        {
            const int Digit = 5;
            calculator.PressKey(Digit);
            return Digit;
        }

        private void ExpectDigitOnDisplay(int digit)
        {
            Assert.That(calculator.Display, Is.EqualTo(digit));
        }

        private CalculatorEngine calculator;
    }
}