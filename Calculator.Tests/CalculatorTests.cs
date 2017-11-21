using System;
using NUnit.Framework;

namespace Calculator.Tests
{
    public class CalculatorTests
    {
        [Test]
        public void PressingDigitKeyDisplaysThatDigit()
        {
            char digit = PressADigitKey();
            ExpectDigitOnDisplay(digit);
        }

        [Test]
        public void PressingTwoDigitKeysDisplaysBothDigitsInTheSameOrder()
        {
            char digit1 = PressADigitKey();
            char digit2 = PressADigitKey();
            ExpectDigitOnDisplay(digit1, digit2);
        }

        [Test]
        public void PressingDotInbetweenDigitsDisplaysTheDot()
        {
            char digit1 = PressADigitKey();
            char digit2 = PressADigitKey();
            PressADotKey();
            char digit3 = PressADigitKey();
            ExpectDigitOnDisplay(digit1, digit2, '.', digit3);
        }

        [SetUp]
        public void Setup()
        {
            calculator = new CalculatorEngine();
            rnd = new Random(123);
        }

        private char PressADigitKey()
        {
            char digit = (char)(rnd.Next(10) + '0');
            calculator.PressKey(digit);
            return digit;
        }

        private void ExpectDigitOnDisplay(params char[] expectedDigits)
        {
            Assert.That(calculator.Display, Is.EqualTo(expectedDigits));
        }

        private CalculatorEngine calculator;
        private Random rnd;
    }
}