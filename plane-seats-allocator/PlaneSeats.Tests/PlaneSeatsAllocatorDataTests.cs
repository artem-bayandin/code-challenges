using PlaneSeats.Common;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace PlaneSeats.Tests
{
    public class PlaneSeatsAllocatorData : IEnumerable<object[]>
    {
        public List<string> SeatLetters = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L" };

        public List<AllocationValue> AllocationValues = new List<AllocationValue>
        {
            AllocationValue.Create(2, "B", "C", "D", "E", "F", "G", "H", "I"),
            AllocationValue.Create(1, "B", "C", "D", "E"),
            AllocationValue.Create(1, "D", "E", "F", "G"),
            AllocationValue.Create(1, "F", "G", "H", "I")
        };

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, "", 2, SeatLetters, AllocationValues };
            yield return new object[] { 2, "1A 2F 1C", 2, SeatLetters, AllocationValues };
            yield return new object[] { 15, "1A 2F 1C 4D 7H 8H 8I 5F 10C 10H 11B 11E 12G", 21, SeatLetters, AllocationValues };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class PlaneSeatsAllocatorDataTests
    {
        [Theory]
        [ClassData(typeof(PlaneSeatsAllocatorData))]
        public void CountFamiliesOf4Tests(int numberOfRows, string seatsMatrix, int expected, List<string> seatLetters, List<AllocationValue> possibleAllocations)
        {
            // arrange
            var allocator = new PlaneSeatsAllocator(numberOfRows, seatsMatrix, seatLetters);

            // act
            var actual = allocator.CountPossibleAllocations(possibleAllocations);

            // assert
            Assert.Equal(expected, actual);
        }


    }
}
