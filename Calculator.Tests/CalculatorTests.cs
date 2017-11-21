using System;
using NUnit.Framework;

namespace Calculator.Tests
{
    public class CalculatorTests
    {
        [Test]
        public void ShowsZeroInitially()
        {
            ExpectDigitOnDisplay(CalculatorEngine.KeyZero);
        }

        [Test]
        public void IgnoresLeadingZeros()
        {
            PressZeroDigit();
            PressZeroDigit();
            PressZeroDigit();
            char digit = PressADigitKey();
            ExpectDigitOnDisplay(digit);
        }

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
            char dotChar = PressADotKey();
            char digit3 = PressADigitKey();
            ExpectDigitOnDisplay(digit1, digit2, dotChar, digit3);
        }

        [Test]
        public void IgnoresTheSecondDotKey()
        {
            char digit1 = PressADigitKey();
            char dotChar = PressADotKey();
            char digit2 = PressADigitKey();
            PressADotKey();
            ExpectDigitOnDisplay(digit1, dotChar, digit2);
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

        private char PressADotKey()
        {
            calculator.PressKey(CalculatorEngine.KeyDot);
            return CalculatorEngine.KeyDot;
        }

        private void ExpectDigitOnDisplay(params char[] expectedDigits)
        {
            Assert.That(calculator.Display, Is.EqualTo(expectedDigits));
        }

        private CalculatorEngine calculator;
        private Random rnd;
    }
}