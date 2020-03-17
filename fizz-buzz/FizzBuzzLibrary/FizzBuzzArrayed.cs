using System.Collections.Generic;
using System.Linq;

namespace FizzBuzzLibrary
{
    public class FizzBuzzArrayed : FizzBuzz
    {
        private List<int> _array = new List<int>();

        public FizzBuzzArrayed(int[] array, Divisor[] divisors) : base(divisors)
        {
            if (array.Length == 0)
            {
                return;
            }
            _array = new List<int>(array)
                .Distinct()
                .Where(x => x > 0)
                .OrderBy(x => x)
                .ToList();
        }

        protected override IEnumerable<int> Items => _array;
    }
}
