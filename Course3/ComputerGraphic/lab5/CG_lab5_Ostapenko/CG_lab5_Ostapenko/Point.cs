using System;

namespace CG_lab5_Ostapenko
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            var comparableCell = obj as Point;
            return (X.Equals(comparableCell.X) && Y.Equals(comparableCell.Y));
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}