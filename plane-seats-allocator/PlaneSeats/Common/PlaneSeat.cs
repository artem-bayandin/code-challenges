using System;

namespace PlaneSeats.Common
{
    public class PlaneSeat
    {
        public int Row { get; }
        public string Letter { get; set; }

        public PlaneSeat(int row, string letter)
        {
            if (row < 0) throw new ApplicationException("Row number must be greater than 0.");
            if (letter.Length != 1) throw new ApplicationException("Seat letter must contain exact 1 character.");

            Row = row;
            Letter = letter;
        }
    }
}
