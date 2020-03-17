using System.Collections.Generic;
using System.Linq;

namespace PlaneSeats.Common
{
    public class Plane
    {
        public List<PlaneRow> Rows { get; } = new List<PlaneRow>();

        public PlaneRow AddRow(int rowNumber)
        {
            var row = Rows.FirstOrDefault(r => r.Number == rowNumber);
            if (row == null)
            {
                row = new PlaneRow(rowNumber);
                Rows.Add(row);
            }
            return row;
        }

        public void AddAllocatedSeat(int rowNumber, string letter)
        {
            var row = AddRow(rowNumber);
            row.AddAllocatedSeat(letter);
        }
    }
}
