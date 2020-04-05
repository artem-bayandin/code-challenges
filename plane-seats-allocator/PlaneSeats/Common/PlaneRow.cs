using System;
using System.Collections.Generic;
using System.Linq;

namespace PlaneSeats.Common
{
    public class PlaneRow
    {
        public int Number { get; private set; }
        public List<PlaneSeat> AllocatedSeats { get; private set; }

        private PlaneRow() { }

        public static PlaneRow Create(int number)
        {
            if (number < 1 || number > 99) throw new ApplicationException("Row is allowed in a range 1..99.");

            return new PlaneRow
            {
                Number = number,
                AllocatedSeats = new List<PlaneSeat>()
            };
        }

        public void AddAllocatedSeat(string letter)
        {
            if (!AllocatedSeats.Any(seat => seat.Letter == letter))
            {
                AllocatedSeats.Add(PlaneSeat.Create(Number, letter));
            }
        }
    }
}
