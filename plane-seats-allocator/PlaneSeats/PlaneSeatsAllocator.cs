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

        public Plane Plane { get; } = new Plane();

        public PlaneSeatsAllocator(int numberOfRows, string allocatedSeatsMatrix)
        {
            NumberOfRows = numberOfRows;
            AllocatedSeatsMatrix = allocatedSeatsMatrix.ToUpper();

            ConvertInputIntoRowsWithAllocatedSeats();
        }

        public int CountFamiliesOf4()
        {
            // this validation added to omit unnecessary iterations if we have 0 seats allocated
            if (String.IsNullOrEmpty(AllocatedSeatsMatrix))
            {
                return NumberOfRows * 2;
            }

            int counter = 0;

            var first = new List<string> { "B", "C", "D", "E" };
            var second = new List<string> { "D", "E", "F", "G" };
            var third = new List<string> { "F", "G", "H", "I" };

            foreach (var row in Plane.Rows)
            {
                var seats = row.AllocatedSeats.Select(s => s.Letter);

                if (first.All(x => !seats.Contains(x)) && third.All(x => !seats.Contains(x)))
                {
                    counter += 2;
                    continue;
                }

                if (first.All(x => !seats.Contains(x))
                    || second.All(x => !seats.Contains(x))
                    || third.All(x => !seats.Contains(x)))
                {
                    counter += 1;
                    continue;
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

                if (row > NumberOfRows) throw new ApplicationException("Row number cannot be greater than total number of rows.");

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
