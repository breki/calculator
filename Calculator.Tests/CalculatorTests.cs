using System;
using System.Globalization;
using System.Linq;
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
            AssertDisplayShowsChars(digit);
        }

        [Test]
        public void PressingDigitKeyDisplaysThatDigit()
        {
            char digit = PressADigitKey();
            AssertDisplayShowsChars(digit);
        }

        [Test]
        public void PressingTwoDigitKeysDisplaysBothDigitsInTheSameOrder()
        {
            char digit1 = PressADigitKey();
            char digit2 = PressADigitKey();
            AssertDisplayShowsChars(digit1, digit2);
        }

        [Test]
        public void PressingDotKeyAtStartDisplaysTheDotAfterZero()
        {
            PressTheDotKey();
            AssertDisplayShowsChars(CalculatorEngine.CharZero, CalculatorEngine.CharDot);
        }

        [Test]
        public void PressingDotInbetweenDigitsDisplaysTheDot()
        {
            char digit1 = PressADigitKey();
            char digit2 = PressADigitKey();
            char dotChar = PressTheDotKey();
            char digit3 = PressADigitKey();
            AssertDisplayShowsChars(digit1, digit2, dotChar, digit3);
        }

        [Test]
        public void IgnoresTheSecondDotKey()
        {
            char digit1 = PressADigitKey();
            char dotChar = PressTheDotKey();
            char digit2 = PressADigitKey();
            PressTheDotKey();
            AssertDisplayShowsChars(digit1, dotChar, digit2);
        }

        [Test]
        public void ClrKeyClearsTheDisplay()
        {
            PressADigitKey();
            PressADigitKey();
            PressTheClrKey();
            AssertDisplayShowsZero();
        }

        [TestCase(CalculatorKey.Equals)]
        [TestCase(CalculatorKey.Plus)]
        [TestCase(CalculatorKey.Minus)]
        [TestCase(CalculatorKey.Multiply)]
        [TestCase(CalculatorKey.Divide)]
        public void PressingOperatorKeyAtStartDoesNothing(CalculatorKey operatorKey)
        {
            PressTheKey(operatorKey);
            AssertDisplayShowsZero();
        }

        [TestCase(CalculatorKey.Equals)]
        [TestCase(CalculatorKey.Plus)]
        [TestCase(CalculatorKey.Minus)]
        [TestCase(CalculatorKey.Multiply)]
        [TestCase(CalculatorKey.Divide)]
        public void EnteringDigitAfterOperatorKeyClearsThePreviousValueFromDisplay(
            CalculatorKey operatorKey)
        {
            PressADigitKey();
            PressTheKey(operatorKey);
            char digit1 = PressADigitKey();
            char digit2 = PressADigitKey();

            AssertDisplayShowsChars(digit1, digit2);
        }

        [TestCase(CalculatorKey.Equals)]
        [TestCase(CalculatorKey.Plus)]
        [TestCase(CalculatorKey.Minus)]
        [TestCase(CalculatorKey.Multiply)]
        [TestCase(CalculatorKey.Divide)]
        public void PressingOperatorKeyAfterDigitsDoesNothing(CalculatorKey operatorKey)
        {
            char digit1 = PressADigitKey();
            char dotChar = PressTheDotKey();
            char digit2 = PressADigitKey();
            PressTheKey(operatorKey);
            AssertDisplayShowsChars(digit1, dotChar, digit2);
        }

        [Test]
        public void PressingPlusKeyAndThenEqualsDoublesTheValue()
        {
            decimal enteredValue = EnterValue();

            PressThePlusKey();
            PressTheEqualsKey();

            AssertDisplayShowsValue(enteredValue * 2);
        }

        [Test]
        public void EnteringValuePlusValueEqualsCalculatesSum()
        {
            decimal value1 = EnterValue();
            PressThePlusKey();
            decimal value2 = EnterValue();

            PressTheEqualsKey();

            AssertDisplayShowsValue(value1 + value2);
        }

        [Test]
        public void PressingMinusKeyAndThenEqualsSetsValueToZero()
        {
            EnterValue();
            PressTheMinusKey();
            PressTheEqualsKey();

            AssertDisplayShowsZero();
        }

        [Test]
        public void EnteringValueMinusValueEqualsSubtractsValues()
        {
            decimal value1 = EnterValue();
            PressTheMinusKey();
            decimal value2 = EnterValue();

            PressTheEqualsKey();

            AssertDisplayShowsValue(value1 - value2);
        }

        [Test]
        public void SubtractingLargerValueFromSmallerOneResultsInNegativeValue()
        {
            const decimal Value1 = 123123.454545m;
            const decimal Value2 = 6573434.23232m;
            TypeInValue(Value1);
            PressTheMinusKey();
            TypeInValue(Value2);
            PressTheEqualsKey();

            AssertDisplayShowsValue(Value1 - Value2);
        }

        [Test]
        public void PressingMultiplyKeyAndThenEqualsSquaresTheValue()
        {
            decimal enteredValue = EnterValue();

            PressTheMultiplyKey();
            PressTheEqualsKey();

            AssertDisplayShowsValue(enteredValue * enteredValue);
        }

        [Test]
        public void EnteringValueMultiplyValueEqualsMultipliesValues()
        {
            decimal value1 = EnterValue();
            PressTheMultiplyKey();
            decimal value2 = EnterValue();

            PressTheEqualsKey();

            AssertDisplayShowsValue(value1 * value2);
        }

        [Test]
        public void PressingDivideKeyAndThenEqualsDividesTheValueWithItself()
        {
            EnterValue();

            PressTheDivideKey();
            PressTheEqualsKey();

            AssertDisplayShowsValue(1);
        }

        [Test]
        public void EnteringValueDivideValueEqualsDividesValues()
        {
            decimal value1 = EnterValue();
            PressTheDivideKey();
            decimal value2 = EnterValue();

            PressTheEqualsKey();

            AssertDisplayShowsValue(value1 / value2);
        }

        [Test]
        public void DividingByZeroCausesTheDisplayToShowError()
        {
            EnterValue();
            PressTheDivideKey();
            TypeInValue(0);

            PressTheEqualsKey();

            AssertDisplayShowsError();
        }

        [Test]
        public void UsesRoundingToLimitHowManyCharactersAreDisplayed()
        {
            TypeInValue(2);
            PressTheDivideKey();
            TypeInValue(3);

            PressTheEqualsKey();

            AssertDisplayShowsText("0.66666667");
        }

        [SetUp]
        public void Setup()
        {
            display = new CalculatorDisplay();
            calculator = new CalculatorEngine(display);
            rnd = new Random(123);
        }

        private decimal EnterValue()
        {
            decimal value = (decimal)(rnd.NextDouble() * 100000);
            TypeInValue(value);

            return value;
        }

        private void TypeInValue(decimal value)
        {
            string valueStr = value.ToString(CultureInfo.InvariantCulture);
            foreach (char c in valueStr)
                PressTheKey(c);
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

        private void PressThePlusKey()
        {
            calculator.PressKey(CalculatorKey.Plus);
        }

        private void PressTheMinusKey()
        {
            calculator.PressKey(CalculatorKey.Minus);
        }

        private void PressTheMultiplyKey()
        {
            calculator.PressKey(CalculatorKey.Multiply);
        }

        private void PressTheDivideKey()
        {
            calculator.PressKey(CalculatorKey.Divide);
        }

        private void PressTheKey(char keyChr)
        {
            if (char.IsDigit(keyChr))
                calculator.PressKey(CalculatorKey.K0 + keyChr - CalculatorEngine.CharZero);
            else if (keyChr == CalculatorEngine.CharDot)
                calculator.PressKey(CalculatorKey.Dot);
            else
                throw new ArgumentException();
        }

        private void PressTheKey(CalculatorKey key)
        {
            calculator.PressKey(key);
        }

        private static decimal ParseDecimalFromChars(params char[] expectedChars)
        {
            return decimal.Parse(string.Concat(expectedChars), CultureInfo.InvariantCulture);
        }

        private void AssertDisplayShowsZero()
        {
            AssertDisplayShowsChars(CalculatorEngine.CharZero);
        }

        private void AssertDisplayShowsChars(params char[] expectedChars)
        {
            Assert.That(
                display.Text, 
                Is.EqualTo(string.Concat(expectedChars)),
                "Calculator display does not show the expected number.");
        }

        private void AssertDisplayShowsValue(decimal expectedValue)
        {
            Assert.That(
                ParseDecimalFromChars(display.Text.ToArray()),
                Is.EqualTo(Math.Round(expectedValue, 8)),
                "Calculator display does not show the expected number.");
        }

        private void AssertDisplayShowsError()
        {
            Assert.That(
                display.Text, 
                Is.EqualTo(CalculatorDisplay.MsgError),
                "Calculator display does not show the expected text.");
        }

        private void AssertDisplayShowsText(string expectedText)
        {
            Assert.That(
                display.Text,
                Is.EqualTo(expectedText),
                "Calculator display does not show the expected text.");
        }

        private CalculatorEngine calculator;
        private Random rnd;
        private CalculatorDisplay display;
    }
}