using System.Collections.Generic;
using System.Linq;

namespace PlaneSeats.Common
{
    public class Plane
    {
        public List<PlaneRow> Rows { get; private set; } = new List<PlaneRow>();

        public PlaneRow AddRow(int rowNumber)
        {
            var row = Rows.FirstOrDefault(r => r.Number == rowNumber);
            if (row == null)
            {
                row = PlaneRow.Create(rowNumber);
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
