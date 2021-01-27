using System.Collections.Generic;

namespace CG_lab5_Ostapenko
{
    public class Figure
    {
        public Line[] Lines { get; set; }

        public Figure(Line[] lines)
        {
            Lines = lines;
        }

        public IEnumerable<Point> GetCells()
        {
            var cells = new List<Point>();

            foreach (var line in Lines)
            {
                var point = new Point(line.X1, line.Y1);
                if (!cells.Contains(point))
                {
                    cells.Add(point);
                }
                
                point = new Point(line.X2, line.Y2);
                if (!cells.Contains(point))
                {
                    cells.Add(point);
                }
            }

            return cells;
        }
    }
}
