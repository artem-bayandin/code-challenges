using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzzLibrary
{
    public abstract class FizzBuzz : IEnumerable<FizzBuzzResult>
    {
        private List<Divisor> _divisors = new List<Divisor>();

        protected FizzBuzz(Divisor[] divisors)
        {
            if (divisors.Length == 0)
            {
                return;
            }
            //if (divisors.Select(d => d.Value).Distinct().Count() != divisors.Length)
            //{
            //    throw new ApplicationException("Divisors must be unique.");
            //}
            _divisors = new List<Divisor>(divisors);
        }

        public IEnumerator<FizzBuzzResult> GetEnumerator()
        {
            foreach (var item in Items)
            {
                var divisors = new List<Divisor>();

                foreach (var divisor in _divisors)
                {
                    if (item % divisor.Value == 0)
                    {
                        divisors.Add(divisor);
                    }
                }

                yield return new FizzBuzzResult(item, divisors);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        protected abstract IEnumerable<int> Items { get; }
    }
}
