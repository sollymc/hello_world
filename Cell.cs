using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoVirusApplication
{
    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public CellType Type { get; set; }

        public List<Cell> GetCells()
        {
            List<Cell> cells = new List<Cell>();
            Random randomNumber = new Random();

            for (int i = 1; i <= 100; i++)
            {
                if (i <= 5)
                {
                    var cell = new Cell
                    {
                        Type = CellType.TumorousCell,
                        X = randomNumber.Next(1, 5001),
                        Y = randomNumber.Next(1, 5001),
                        Z = randomNumber.Next(1, 5001)
                    };

                    cells.Add(cell);
                }

                if (i > 5 && i <= 30)
                {
                    var cell = new Cell
                    {
                        Type = CellType.WhiteBloodCell,
                        X = randomNumber.Next(1, 5001),
                        Y = randomNumber.Next(1, 5001),
                        Z = randomNumber.Next(1, 5001)
                    };

                    cells.Add(cell);
                }

                if (i > 30)
                {
                    var cell = new Cell
                    {
                        Type = CellType.RedBloodCell,
                        X = randomNumber.Next(1, 5001),
                        Y = randomNumber.Next(1, 5001),
                        Z = randomNumber.Next(1, 5001)
                    };

                    cells.Add(cell);
                }
            }

            return cells;
        }
    
    }
}
