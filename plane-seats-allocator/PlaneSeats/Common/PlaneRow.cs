using System;
using System.Collections.Generic;
using System.Linq;

namespace PlaneSeats.Common
{
    public class PlaneRow
    {
        public int Number { get; }
        public List<PlaneSeat> AllocatedSeats { get; } = new List<PlaneSeat>();

        public PlaneRow(int number)
        {
            if (number < 0) throw new ApplicationException("Row number must be greater than 0.");
            Number = number;
        }

        public void AddAllocatedSeat(string letter)
        {
            if (!AllocatedSeats.Any(seat => seat.Letter == letter))
            {
                AllocatedSeats.Add(new PlaneSeat(Number, letter));
            }
        }
    }
}
