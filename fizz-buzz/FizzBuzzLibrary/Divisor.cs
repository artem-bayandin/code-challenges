using System;

namespace FizzBuzzLibrary
{
    public class Divisor
    {
        public int Value { get; }
        public string Text { get; }

        public Divisor(int value, string text)
        {
            if (value < 1) throw new ApplicationException("Divisor value must be greater than 0.");
            if (String.IsNullOrEmpty(text)) throw new ApplicationException("Text should contain at least 1 char.");

            Value = value;
            Text = text;
        }
    }
}
