using System;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzzLibrary
{
    public class FizzBuzzResult
    {
        private const string _noDivisors = "[no divisors]";
        private int _item;
        private List<Divisor> _divisors;

        public FizzBuzzResult(int item, List<Divisor> divisors)
        {
            _item = item;
            _divisors = divisors;
        }

        public override string ToString()
        {
            var result = _divisors.Any() ? String.Join("", _divisors.Select(d => d.Text)) : _noDivisors;

            return $"{_item} : {result}";
        }
    }
}
