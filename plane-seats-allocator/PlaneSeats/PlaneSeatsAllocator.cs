using PlaneSeats.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlaneSeats
{
    public class PlaneSeatsAllocator
    {
        public int NumberOfRows { get; }
        public string AllocatedSeatsMatrix { get; }
        public List<string> SeatLetters { get; }

        public Plane Plane { get; } = new Plane();

        public PlaneSeatsAllocator(int numberOfRows
            , string allocatedSeatsMatrix
            , List<string> seatLetters
            )
        {
            NumberOfRows = numberOfRows;
            AllocatedSeatsMatrix = allocatedSeatsMatrix.ToUpper();
            SeatLetters = seatLetters ?? new List<string>();

            ConvertInputIntoRowsWithAllocatedSeats();
        }

        public int CountPossibleAllocations(List<AllocationValue> possibleAllocationsWithValue)
        {
            if (possibleAllocationsWithValue == null || possibleAllocationsWithValue.Count == 0) throw new ApplicationException("Collection of values should not be null or empty.");

            // this validation added to omit unnecessary iterations if we have 0 seats allocated
            if (String.IsNullOrEmpty(AllocatedSeatsMatrix))
            {
                return NumberOfRows * possibleAllocationsWithValue.Max(v => v.Value);
            }

            int counter = 0;

            foreach (var row in Plane.Rows)
            {
                var seats = row.AllocatedSeats.Select(s => s.Letter).ToList();

                foreach (var possibleAllocation in possibleAllocationsWithValue.OrderByDescending(x => x.Value))
                {
                    if (possibleAllocation.Letters.All(x => !seats.Contains(x)))
                    {
                        counter += possibleAllocation.Value;
                        break;
                    }
                }
            }

            return counter;
        }

        private void ConvertInputIntoRowsWithAllocatedSeats()
        {
            if (String.IsNullOrEmpty(AllocatedSeatsMatrix))
            {
                return;
            }

            foreach (var taken in AllocatedSeatsMatrix.Split(' '))
            {
                if (taken.Length > 3) throw new ArgumentException("Name of seat might contain 1 or 2 digits of row number and 1 char for seat letter.");

                int row;
                string letter;
                if (taken.Length == 2)
                {
                    row = Int32.Parse(taken.Substring(0, 1));
                    letter = taken.Substring(1, 1);
                }
                else
                {
                    row = Int32.Parse(taken.Substring(0, 2));
                    letter = taken.Substring(2, 1);
                }

                if (row > NumberOfRows) throw new ArgumentException("Row number cannot be greater than total number of rows.");
                if (!SeatLetters.Contains(letter)) throw new ArgumentException("Allocated seat letter should be in list of available letters.");

                Plane.AddAllocatedSeat(row, letter);
            }

            // add empty rows
            for (var i = 1; i <= NumberOfRows; i++)
            {
                Plane.AddRow(i);
            }
        }
    }
}
