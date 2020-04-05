using System;
using System.Collections.Generic;
using System.Linq;

namespace PlaneSeats.Common
{
    public class AllocationValue
    {
        public List<string> Letters { get; private set; }
        public int Value { get; private set; }

        private AllocationValue() { }

        public static AllocationValue Create(int value, params string[] letters)
        {
            if (letters == null || letters.Length == 0) throw new ApplicationException("Collection of letters should not be null or empty.");
            if (letters.Distinct().Count() != letters.Length) throw new ApplicationException("No duplicate in letters is allowed.");
            if (value < 1) throw new ApplicationException("Value should be greater than 0.");

            return new AllocationValue
            {
                Letters = new List<string>(letters),
                Value = value
            };
        }
    }
}
