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
            if (row < 0) throw new ApplicationException("Row number must be greater than 0.");
            if (letter.Length != 1) throw new ApplicationException("Seat letter must contain exact 1 character.");

            return new PlaneSeat
            {
                Row = row,
                Letter = letter
            };
        }
    }
}
