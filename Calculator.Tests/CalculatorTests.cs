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

        [Test]
        public void ClrKeyClearsTheDisplay()
        {
            PressADigitKey();
            PressADigitKey();
            PressClrKey();
            ExpectDigitOnDisplay(CalculatorEngine.KeyZero);
        }

        [SetUp]
        public void Setup()
        {
            calculator = new CalculatorEngine();
            rnd = new Random(123);
        }

        private char PressADigitKey()
        {
            CalculatorKey digit = rnd.Next(10) + CalculatorKey.K0;
            calculator.PressKey(digit);
            return (char)(digit - CalculatorKey.K0 + '0');
        }

        private void PressZeroDigit()
        {
            calculator.PressKey(CalculatorKey.K0);
        }

        private char PressADotKey()
        {
            calculator.PressKey(CalculatorKey.Dot);
            return CalculatorEngine.KeyDot;
        }

        private void PressClrKey()
        {
            calculator.PressKey(CalculatorKey.Clr);
        }

        private void ExpectDigitOnDisplay(params char[] expectedDigits)
        {
            Assert.That(
                calculator.Display, 
                Is.EqualTo(expectedDigits),
                "Calculator display does not show the expected number.");
        }

        private CalculatorEngine calculator;
        private Random rnd;
    }
}