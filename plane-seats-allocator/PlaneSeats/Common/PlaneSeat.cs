using System;

namespace PlaneSeats.Common
{
    public class PlaneSeat
    {
        public int Row { get; private set; }
        public string Letter { get; private set; }

        private PlaneSeat() { }

        public static PlaneSeat Create(int row, string letter)
        {
            if (row < 1 || row > 99) throw new ApplicationException("Row is allowed in a range 1..99.");
            if (letter.Length != 1) throw new ApplicationException("Seat letter must contain exact 1 character.");

            return new PlaneSeat
            {
                Row = row,
                Letter = letter
            };
        }
    }
}
