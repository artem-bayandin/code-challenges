using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace PlaneSeats.Tests
{
    public class PlaneSeatsAllocatorData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, "", 2 };
            yield return new object[] { 2, "1A 2F 1C", 2 };
            yield return new object[] { 15, "1A 2F 1C 4D 7H 8H 8I 5F 10C 10H 11B 11E 12G", 21 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class PlaneSeatsAllocatorDataTests
    {
        [Theory]
        [ClassData(typeof(PlaneSeatsAllocatorData))]
        public void CountFamiliesOf4Tests(int numberOfRows, string seatsMatrix, int expected)
        {
            // arrange
            var allocator = new PlaneSeatsAllocator(numberOfRows, seatsMatrix);

            // act
            var actual = allocator.CountFamiliesOf4();

            // assert
            Assert.Equal(expected, actual);
        }


    }
}
