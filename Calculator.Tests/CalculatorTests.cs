using System;
using NUnit.Framework;

namespace Calculator.Tests
{
    public class CalculatorTests
    {
        [Test]
        public void ShowsZeroInitially()
        {
            AssertDisplayShowsZero();
        }

        [Test]
        public void IgnoresLeadingZeros()
        {
            PressTheZeroKey();
            PressTheZeroKey();
            PressTheZeroKey();
            char digit = PressADigitKey();
            AssertDisplayShows(digit);
        }

        [Test]
        public void PressingDigitKeyDisplaysThatDigit()
        {
            char digit = PressADigitKey();
            AssertDisplayShows(digit);
        }

        [Test]
        public void PressingTwoDigitKeysDisplaysBothDigitsInTheSameOrder()
        {
            char digit1 = PressADigitKey();
            char digit2 = PressADigitKey();
            AssertDisplayShows(digit1, digit2);
        }

        [Test]
        public void PressingDotInbetweenDigitsDisplaysTheDot()
        {
            char digit1 = PressADigitKey();
            char digit2 = PressADigitKey();
            char dotChar = PressTheDotKey();
            char digit3 = PressADigitKey();
            AssertDisplayShows(digit1, digit2, dotChar, digit3);
        }

        [Test]
        public void IgnoresTheSecondDotKey()
        {
            char digit1 = PressADigitKey();
            char dotChar = PressTheDotKey();
            char digit2 = PressADigitKey();
            PressTheDotKey();
            AssertDisplayShows(digit1, dotChar, digit2);
        }

        [Test]
        public void ClrKeyClearsTheDisplay()
        {
            PressADigitKey();
            PressADigitKey();
            PressTheClrKey();
            AssertDisplayShowsZero();
        }

        [Test]
        public void PressingEqualsKeyAfterDigitsDoesNothing()
        {
            char digit1 = PressADigitKey();
            char dotChar = PressTheDotKey();
            char digit2 = PressADigitKey();
            PressTheEqualsKey();
            AssertDisplayShows(digit1, dotChar, digit2);
        }

        [Test]
        public void PressingPlusKeyAndThenEqualsDoublesTheValue()
        {
            char digit1 = PressADigitKey();
            char dotChar = PressTheDotKey();
            char digit2 = PressADigitKey();
            decimal expectedValue = ConstructExpectedValue(digit1, dotChar, digit2);

            PressThePlusKey();
            PressTheEqualsKey();

            AssertDisplayShows(expectedValue * 2);
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
            return (char)(digit - CalculatorKey.K0 + CalculatorEngine.CharZero);
        }

        private void PressTheZeroKey()
        {
            calculator.PressKey(CalculatorKey.K0);
        }

        private char PressTheDotKey()
        {
            calculator.PressKey(CalculatorKey.Dot);
            return CalculatorEngine.CharDot;
        }

        private void PressTheClrKey()
        {
            calculator.PressKey(CalculatorKey.Clr);
        }

        private void PressTheEqualsKey()
        {
            calculator.PressKey(CalculatorKey.Equals);
        }

        private void AssertDisplayShowsZero()
        {
            AssertDisplayShows(CalculatorEngine.CharZero);
        }

        private void AssertDisplayShows(params char[] expectedChars)
        {
            Assert.That(
                string.Concat(calculator.Display), 
                Is.EqualTo(string.Concat(expectedChars)),
                "Calculator display does not show the expected number.");
        }

        private CalculatorEngine calculator;
        private Random rnd;
    }
}