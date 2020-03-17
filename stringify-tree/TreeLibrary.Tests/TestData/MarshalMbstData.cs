using System.Collections;
using System.Collections.Generic;
using TreeLibrary.Tests.Constants;

namespace TreeLibrary.Tests.TestData
{
    public class MarshalMbstData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            foreach (var delimiter in TestConstants.Delimiters)
            {
                foreach (var amount in TestConstants.NumbersOfNodes)
                {
                    yield return new object[] { delimiter, amount };
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
