﻿using System.Collections.Generic;

namespace Calculator
{
    public class CalculatorEngine
    {
        public CalculatorEngine()
        {
            Initialize();
        }

        public const char CharDot = '.';
        public const char CharZero = '0';

        public IReadOnlyList<char> Display => keyChars;

        public void PressKey(CalculatorKey keyPressed)
        {
            if (keyChars.Count == 1 && keyChars[0] == CharZero)
                keyChars.Clear();

            if (keyPressed == CalculatorKey.Dot)
            {
                if (keyChars.Contains(CharDot))
                    return;
                
                keyChars.Add(CharDot);
                return;
            }

            if (keyPressed == CalculatorKey.Clr)
            {
                keyChars.Clear();
                Initialize();
                return;
            }

            char keyChar = (char)(keyPressed - CalculatorKey.K0 + CharZero);

            keyChars.Add(keyChar);
        }

        private void Initialize()
        {
            keyChars.Clear();
            keyChars.Add(CharZero);
        }

        private readonly List<char> keyChars = new List<char>();
    }
}