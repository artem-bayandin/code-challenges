using System.Collections.Generic;

namespace FizzBuzzLibrary
{
    public class FizzBuzzRanged : FizzBuzz
    {
        private int _start;
        private int _end;

        public FizzBuzzRanged(int end, Divisor[] divisors) : this(1, end, divisors)
        {
        }

        public FizzBuzzRanged(int start, int end, Divisor[] divisors) : base(divisors)
        {
            _start = start > 0 ? start : 1;
            _end = end > _start ? end : _start;
        }

        protected override IEnumerable<int> Items
        {
            get
            {
                for (var i = _start; i <= _end; i++)
                {
                    yield return i;
                }
            }
        }
    }
}
