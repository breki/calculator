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

        [SetUp]
        public void Setup()
        {
            calculator = new CalculatorEngine();
        }

        private int PressANumberKey()
        {
            const int Number = 5;
            calculator.PressKey(Number);
            return Number;
        }

        private void ExpectNumberOnDisplay(int number)
        {
            Assert.That(calculator.Display, Is.EqualTo(number));
        }

        private CalculatorEngine calculator;
    }
}